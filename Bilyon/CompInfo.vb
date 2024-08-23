Imports Newtonsoft.Json

Public Class DriveInfo
    Public Property DriveLetter As String
    Public Property FreeSpace As Long
    Public Property TotalSpace As Long
End Class

Public Class Battery
    Public Property BatteryStatus As String
    Public Property BatteryLevel As Integer
End Class

Public Class NInterface
    Public Property MacAddress As String
    Public Property Status As String
    Public Property IPAddress As String
End Class

Public Class Screen
    Public Property Model As String
    Public Property Resolution As String
    Public Property RefreshRate As String
End Class

Public Class CPU
    Public Property Model As String
    Public Property Cores As Integer
    Public Property CPUUtilization As Single
End Class

Public Class RAM
    Public Property Model As String
    Public Property Capacity As String
End Class

Public Class CompInfo
    Public Property GUID As String
    Public Property CPUModel As CPU
    Public Property MotherboardModel As String
    Public Property RAMDevice As List(Of RAM)
    Public Property RAMUtilization As Single
    Public Property GPUModel As String
    Public Property Drives As List(Of DriveInfo)
    Public Property Screens As List(Of Screen)
    Public Property NetworkInterfaces As List(Of NInterface)
    Public Property Uptime As TimeSpan
    Public Property RTCTime As DateTime
    Public Property BatteryDevice As Battery
    Public Property WindowsVersion As String
    Public Property WindowsRegionLanguage As String
    Public Property CurrentUserName As String
    Public Property CurrentUserType As String
    Public Property FocusedApplicationName As String
    Public Property RunningPrograms As List(Of String)
    Public Property InstalledPrograms As List(Of String)

    Public Sub New()
        Drives = New List(Of DriveInfo)()
        Screens = New List(Of Screen)()
        NetworkInterfaces = New List(Of NInterface)()
        RAMDevice = New List(Of RAM)()
        RunningPrograms = New List(Of String)()
        InstalledPrograms = New List(Of String)()
    End Sub

    Public Function ToJson() As String
        Return JsonConvert.SerializeObject(Me, Formatting.Indented)
    End Function
End Class