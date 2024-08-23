Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices.Marshalling
Imports BilYon.Extentions
Imports Microsoft.VisualBasic.Devices
Imports Newtonsoft.Json

Public Class ComputerInfo
    Inherits System.Windows.Forms.Form

    Public CompGUID As String

    Private _Comp As Computers
    Private _CompDetail As CompDetail

    Private RAGV_SI As Integer
    Private IAGV_SI As Integer

    Private Shared _instance As New ComputerInfo
    Public Shared ReadOnly Property Instance() As ComputerInfo
        Get
            Return _instance
        End Get
    End Property

    Private Sub CloseForm()
        _Comp = New Computers
        _CompDetail = New CompDetail
        CompGUID = "-1"
        CompNameLabel.Text = "DESKTOP-HT4GS"
        IPLabel.Text = "IP: 127.0.0.1"
        MACLabel.Text = "MAC: DB:14:E2:CB:53:32"
        StatusLabel.Text = "Çevrimdışı"
        StatusLabel.ForeColor = Color.Red
        StatusUpdateTimer.Enabled = False
        ScreenFlowLayout.Controls.Clear()
        InstalledAppsGV.Rows.Clear()
        InstalledAppsGV.Columns.Clear()
        RunningAppsInfoGV.Rows.Clear()
        RunningAppsInfoGV.Columns.Clear()
        InfoTabs.SelectedTab = InfoTab
        IAGV_SI = -1
        RAGV_SI = -1

        Me.Hide()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        CloseForm()
    End Sub

    Private Sub ComputerInfo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CompGUID IsNot "-1" Then
            Using db As New AppDbContext()
                Try
                    Dim Computer = db.Computers.FirstOrDefault(Function(p) p.GUID = CompGUID)
                    Dim ComputerDetail = db.CompDetail.FirstOrDefault(Function(p) p.GUID = CompGUID)
                    _Comp = Computer
                    _CompDetail = ComputerDetail
                Catch ex As Exception
                    My.Application.Log.WriteEntry("Failed to get computer info for displaying. Error: " + ex.Message)
                    CloseForm()
                    Exit Sub
                End Try
            End Using

            CompNameLabel.Text = _Comp.Host_Name
            IPLabel.Text = "IP: " + _Comp.Local_Ip
            MACLabel.Text = "MAC: " + FormatMacAddress(_Comp.Mac_Adress)
            StatusUpdateTimer.Enabled = True

            Update_Info()
            UpdateStatus()
        End If
    End Sub

    Private Async Sub UpdateStatus()
        If Await PingHost(_Comp.Local_Ip) Then
            StatusLabel.Text = "Çevrimiçi"
            StatusLabel.ForeColor = Color.Green
        Else
            StatusLabel.Text = "Çevrimdışı"
            StatusLabel.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Update_Info()
        If CompGUID IsNot "-1" Then
            Using db As New AppDbContext()
                Try
                    Dim Computer = db.Computers.FirstOrDefault(Function(p) p.GUID = CompGUID)
                    Dim ComputerDetail = db.CompDetail.FirstOrDefault(Function(p) p.GUID = CompGUID)
                    _Comp = Computer
                    _CompDetail = ComputerDetail
                Catch ex As Exception
                    My.Application.Log.WriteEntry("Failed to get computer info for displaying. Error: " + ex.Message)
                    CloseForm()
                    Exit Sub
                End Try
            End Using
        End If

        CPUModelLabel.Text = "İşlemci : " + _CompDetail.CPU_Model
        CPUCoreLabel.Text = "Çekirdek Sayısı : " + Str(_CompDetail.CPU_Cores)
        CPUUtilLabel.Text = "İşlemci Kullanımı : " + _CompDetail.CPU_Util + "%"

        Dim ramList As New List(Of RAM)()

        For Each jsonString As String In _CompDetail.RAMDevice
            Dim ramObject As RAM = JsonConvert.DeserializeObject(Of RAM)(jsonString)
            ramList.Add(ramObject)
        Next

        Dim totalCapacityInMB As Integer = 0

        For Each ram In ramList
            Dim capacity As Integer = Integer.Parse(ram.Capacity.Substring(0, ram.Capacity.Length - 3))
            totalCapacityInMB += capacity
        Next

        TotalRamLabel.Text = "Toplam Ram : " + Str(totalCapacityInMB / 1024) + " GB"
        RamUtilLabel.Text = "Kullanılan Ram : " + Str((totalCapacityInMB - _CompDetail.RAMUtilization) / 1024) + " GB"

        MotherboardLabel.Text = "Anakart Modeli : " + _CompDetail.MotherboardModel
        GPUModelLabel.Text = "Ekran Kartı Modeli : " + _CompDetail.GPUModel
        RTCLabel.Text = "Bios Zamanı : " + _CompDetail.RTCTime.ToShortDateString + " " + _CompDetail.RTCTime.ToLongTimeString
        UptimeLabel.Text = "Açık Kalma Süresi : " + _CompDetail.Uptime.ToString

        WindowsVersionLabel.Text = "Windows Sürümü : " + _CompDetail.WindowsVersion
        WindowsLocaleLabel.Text = "Windows Dil ve Bölge Ayarı : " + _CompDetail.WindowsRegionLanguage
        UserNameLabel.Text = "Kullanıcı İsmi : " + _CompDetail.CurrentUserName
        UserTypeLabel.Text = "Kullanıcı Tipi : " + _CompDetail.CurrentUserType

        BatteryStatusLabel.Text = "Batarya Durumu : " + _CompDetail.BatteryStatus
        BatteryLevelLabel.Text = "Batarya Seviyesi : " + Str(_CompDetail.BatteryLevel) + "%"

        FocusedAppLabel.Text = _CompDetail.FocusedApplicationName

        If RunningAppsInfoGV.RowCount > 0 Then
            RAGV_SI = RunningAppsInfoGV.FirstDisplayedScrollingRowIndex
        End If

        RunningAppsInfoGV.Rows.Clear()
        RunningAppsInfoGV.Columns.Clear()

        Dim columnName As String = "ProgramNameColumn"
        RunningAppsInfoGV.Columns.Add(columnName, "Program Name")

        For Each programName As String In _CompDetail.RunningPrograms
            RunningAppsInfoGV.Rows.Add(programName)
        Next

        If RAGV_SI > 0 Then
            RunningAppsInfoGV.FirstDisplayedScrollingRowIndex = RAGV_SI
        End If

        If InstalledAppsGV.RowCount > 0 Then
            IAGV_SI = InstalledAppsGV.FirstDisplayedScrollingRowIndex
        End If

        InstalledAppsGV.Rows.Clear()
        InstalledAppsGV.Columns.Clear()

        InstalledAppsGV.Columns.Add(columnName, "Program Name")

        For Each programName As String In _CompDetail.InstalledPrograms
            InstalledAppsGV.Rows.Add(programName)
        Next

        If IAGV_SI > 0 Then
            InstalledAppsGV.FirstDisplayedScrollingRowIndex = IAGV_SI
        End If

        ScreenFlowLayout.Controls.Clear()

        Dim screenList As New List(Of Screen)()

        For Each jsonString As String In _CompDetail.Screens
            Dim screenObject As Screen = JsonConvert.DeserializeObject(Of Screen)(jsonString)
            screenList.Add(screenObject)
        Next

        For Each screen In screenList
            Dim screenUC As ScreenTile = New ScreenTile
            screenUC.SetValues(screen)
            ScreenFlowLayout.Controls.Add(screenUC)
        Next

        RamFlowLayout.Controls.Clear()

        For Each ram In ramList
            Dim ramUC As RamTile = New RamTile
            ramUC.SetValues(ram)
            RamFlowLayout.Controls.Add(ramUC)
        Next

        DriveFlowLayout.Controls.Clear()

        Dim driveList As New List(Of DriveInfo)()

        For Each jsonString As String In _CompDetail.Drives
            Dim driveObject As DriveInfo = JsonConvert.DeserializeObject(Of DriveInfo)(jsonString)
            driveList.Add(driveObject)
        Next

        For Each drive In driveList
            Dim driveUC As DriveTile = New DriveTile
            driveUC.SetValues(drive)
            DriveFlowLayout.Controls.Add(driveUC)
        Next

        NetworkFlowLayout.Controls.Clear()

        Dim networkList As New List(Of NInterface)()

        For Each jsonString As String In _CompDetail.NetworkInterfaces
            Dim networkObject As NInterface = JsonConvert.DeserializeObject(Of NInterface)(jsonString)
            networkList.Add(networkObject)
        Next

        For Each network In networkList
            Dim networkUC As NetworkTile = New NetworkTile
            networkUC.SetValues(network)
            NetworkFlowLayout.Controls.Add(networkUC)
        Next
    End Sub

    Private Sub StatusUpdateTimer_Tick(sender As Object, e As EventArgs) Handles StatusUpdateTimer.Tick
        If CompGUID IsNot "-1" Then
            Update_Info()
            UpdateStatus()
        End If
    End Sub

    Private Sub SendApp_Click(sender As Object, e As EventArgs) Handles SendApp.Click
        Dim FileSender As New TcpFileSender()
        FileSender.SendFile(_Comp.Local_Ip, 42002)
    End Sub

    Private Sub DeleteComputerButton_Click(sender As Object, e As EventArgs) Handles DeleteComputerButton.Click
        StatusUpdateTimer.Enabled = False
        Using db As New AppDbContext()
            Try
                Dim Computer = db.Computers.FirstOrDefault(Function(p) p.GUID = CompGUID)
                Dim ComputerDetail = db.CompDetail.FirstOrDefault(Function(p) p.GUID = CompGUID)
                Dim LastSeen = db.LastSeen.FirstOrDefault(Function(p) p.COMP_GUID = CompGUID)

                If Computer IsNot Nothing Then
                    db.Computers.Remove(Computer)
                End If
                If ComputerDetail IsNot Nothing Then
                    db.CompDetail.Remove(ComputerDetail)
                End If
                If LastSeen IsNot Nothing Then
                    db.LastSeen.Remove(LastSeen)
                End If

                db.SaveChanges()

                CloseForm()
            Catch ex As Exception
                My.Application.Log.WriteEntry("Failed to delete computer from database. Error: " + ex.Message)
                CloseForm()
                Exit Sub
            End Try
        End Using
    End Sub
End Class