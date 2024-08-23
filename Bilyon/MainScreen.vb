Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainScreen
    Inherits System.Windows.Forms.Form

    Public server As New WebSocketServer

    Private Shared _instance As New MainScreen
    Public Shared ReadOnly Property Instance() As MainScreen
        Get
            Return _instance
        End Get
    End Property

    Private Sub FirstTimeInit()
        'MessageBox.Show("This is the first time init.")

        Using db As New AppDbContext()
            Dim PingFreq = db.Settings.FirstOrDefault(Function(p) p.Setting = "PingFrequency")
            If PingFreq Is Nothing Then
                Dim pFreq As New Settings With {
                    .Setting = "PingFrequency",
                    .Value = "5"
                }
                db.Settings.Add(pFreq)
                db.SaveChanges()
            Else
                PingFreq.Value = "5"
                db.SaveChanges()
            End If
        End Using

        ' Do first time init setup here
    End Sub

    Private Async Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New AppDbContext()
            Dim isFirstTime = db.Settings.FirstOrDefault(Function(p) p.Setting = "FirstTime")
            If isFirstTime Is Nothing Then
                Dim firstTime As New Settings With {
                    .Setting = "FirstTime",
                    .Value = "False"
                }
                db.Settings.Add(firstTime)
                db.SaveChanges()

                FirstTimeInit()
            ElseIf isFirstTime.Value Then
                isFirstTime.Value = "False"
                db.SaveChanges()

                FirstTimeInit()
            End If

            Dim Comps = db.Computers.ToList()
            For Each Computer As Computers In Comps
                Dim newTile As New CompInfoTile()
                newTile.SetValues(Computer)
                ComputerFlowPanel.Controls.Add(newTile)
            Next

            Dim AddCompUC As New AddCompTile()
            ComputerFlowPanel.Controls.Add(AddCompUC)

            Await server.StartListeningAsync()
        End Using
    End Sub

    Public Sub UpdateFlow()
        ComputerFlowPanel.Controls.Clear()

        Using db As New AppDbContext()
            Dim Comps = db.Computers.ToList()
            For Each Computer As Computers In Comps
                Dim newTile As New CompInfoTile()
                newTile.SetValues(Computer)
                ComputerFlowPanel.Controls.Add(newTile)
            Next

            Dim AddCompUC As New AddCompTile()
            ComputerFlowPanel.Controls.Add(AddCompUC)
        End Using
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsScreen.Instance.ShowDialog()
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        TrayIcon.Visible = False
    End Sub

    Private Sub MainScreen_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Hide()
            TrayIcon.Visible = True
            TrayIcon.ShowBalloonTip(1000)
        End If
    End Sub

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        UpdateFlow()
    End Sub
End Class
