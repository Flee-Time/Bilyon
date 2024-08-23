Imports System.Net.WebSockets
Imports Microsoft.Win32
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports BilCon.Extentions
Imports BilCon.CompInfo
Imports NetFwTypeLib

Public Class BilConMain
    Public client As New WebSocketClient
    Public ClientGUID As String
    Public ServerIP As String
    Public SendFrequency As Integer
    Public keyPath As String = "Software\KorayBilir\BilCon"
    Private WithEvents receiver As New TcpFileReceiver()

    Private Shared _instance As New BilConMain
    Public Shared ReadOnly Property Instance() As BilConMain
        Get
            Return _instance
        End Get
    End Property

    Private Sub BilConMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Hide()
            TrayIcon.Visible = True
            TrayIcon.ShowBalloonTip(1000)
        End If
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        TrayIcon.Visible = False
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        Hide()
        TrayIcon.Visible = True
        TrayIcon.ShowBalloonTip(1000)
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsScreen.Instance.ShowDialog()
    End Sub

    Private Sub BilConMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsAppAlreadyRunning() Then
            MsgBox("Hata: Uygulama zaten açık, lütfen görev çubuğunuzdaki gizli ikonlara bakınız.", MsgBoxStyle.Critical, "Hata")
            Environment.Exit(1)
            Return
        End If

        Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath)

        If regKey IsNot Nothing Then
            Dim isFirstTime As Object = regKey.GetValue("isFirstTime")

            If isFirstTime IsNot Nothing AndAlso isFirstTime = False Then
                Dim regGUID As Object = regKey.GetValue("clientGUID")
                Dim regIP As Object = regKey.GetValue("serverIP")

                If regIP IsNot Nothing AndAlso regGUID IsNot Nothing Then
                    ClientGUID = regGUID.ToString()
                    ServerIP = regIP.ToString()
                    Dim regFreq As Object = regKey.GetValue("sendFrequency")
                    SendFrequency = If(regFreq IsNot Nothing, CInt(regFreq.ToString()), 5000)
                Else
                    regKey.Close()
                    DeleteRegs()
                    FirstTime()
                    Exit Sub
                End If
            Else
                regKey.Close()
                DeleteRegs()
                FirstTime()
            End If
        Else
            FirstTime()
        End If

        ServerIPText.Text = ServerIP
        SendInterval.Interval = SendFrequency
        SendInterval.Enabled = True

        Dim saveDirectory As String = "C:\path\to\save\received"

        Task.Run(Function() receiver.StartListeningAsync(42002))
    End Sub

    Private Sub FirstTime()
        If Not IsAdmin() Then
            Dim startInfo As New ProcessStartInfo()
            startInfo.UseShellExecute = True
            startInfo.WorkingDirectory = Environment.CurrentDirectory
            startInfo.FileName = Application.ExecutablePath
            startInfo.Verb = "runas"
            Try
                Process.Start(startInfo)
            Catch ex As Exception

            End Try
            Environment.Exit(0)
        End If
        Dim createdRegKey As RegistryKey = Registry.CurrentUser.CreateSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim newGuid As Guid = Guid.NewGuid()

        createdRegKey.SetValue("isFirstTime", False, RegistryValueKind.DWord)
        createdRegKey.SetValue("clientGUID", newGuid.ToString(), RegistryValueKind.String)
        createdRegKey.SetValue("sendFrequency", "5000", RegistryValueKind.String)
        ClientGUID = newGuid.ToString()

        createdRegKey.Close()

        If Not RuleExists("BilCon") Then
            AddPortRule(4202, "BilCon", "Allow traffic on port 4202 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN)
            AddPortRule(4201, "BilCon", "Allow traffic on port 4201 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN)
            AddPortRule(4200, "BilCon", "Allow traffic on port 4200 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN)
            AddPortRule(4202, "BilCon", "Allow traffic on port 4202 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT)
            AddPortRule(4201, "BilCon", "Allow traffic on port 4201 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT)
            AddPortRule(4200, "BilCon", "Allow traffic on port 4200 for BilCon", NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT)
        End If

        PairingScreen.Instance.ShowDialog()
        CheckRegs()
    End Sub

    Private Sub CheckRegs()
        Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath)

        If regKey IsNot Nothing Then
            Dim regGUID As Object = regKey.GetValue("clientGUID")
            Dim regIP As Object = regKey.GetValue("serverIP")
            Dim regFreq As Object = regKey.GetValue("sendFrequency")

            If regGUID IsNot Nothing AndAlso regIP IsNot Nothing Then
                ClientGUID = regGUID.ToString()
                ServerIP = regIP.ToString()
                SendFrequency = If(regFreq IsNot Nothing, CInt(regFreq.ToString()), 5000)
                SendInterval.Interval = SendFrequency
            Else
                FirstTime()
            End If
        Else
            FirstTime()
        End If
    End Sub

    Public Sub DeleteRegs()
        Dim parentKeyPath As String = keyPath.Substring(0, keyPath.LastIndexOf("\"))
        Dim parentKey As RegistryKey = Registry.CurrentUser.OpenSubKey(parentKeyPath, True)

        If parentKey IsNot Nothing Then
            parentKey.DeleteSubKeyTree(keyPath.Substring(keyPath.LastIndexOf("\") + 1))
            parentKey.Close()
        End If
    End Sub

    Private Async Sub SendInterval_Tick(sender As Object, e As EventArgs) Handles SendInterval.Tick
        ServerIPText.Text = ServerIP

        Dim computerInfo As New ComputerInfo()

        computerInfo = Await Task.Run(Function() GetCompInfo(ClientGUID))
        If computerInfo.CPUModel.Model IsNot Nothing Then
            Dim jsonString As String = computerInfo.ToJson()

            Dim success As Boolean = Await client.SendJSON(ServerIP, jsonString)
            If Not success Then
                ServerStatusText.Text = "Çevrimdışı"
                ServerStatusText.ForeColor = Color.Red
            Else
                ServerStatusText.Text = "Çevrimiçi"
                ServerStatusText.ForeColor = Color.Green
            End If
        End If
    End Sub
End Class
