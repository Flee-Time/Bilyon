Imports System.ComponentModel.DataAnnotations

Public Class CompDetail
    <Key>
    <MaxLength(36)>
    Public Property GUID As String
    Public Property CPU_Model As String
    Public Property CPU_Cores As String
    Public Property CPU_Util As String
    Public Property MotherboardModel As String
    Public Property RAMDevice As List(Of String)
    Public Property RAMUtilization As Single
    Public Property GPUModel As String
    Public Property Drives As List(Of String)
    Public Property Screens As List(Of String)
    Public Property NetworkInterfaces As List(Of String)
    Public Property Uptime As TimeSpan
    Public Property RTCTime As DateTime
    Public Property BatteryStatus As String
    Public Property BatteryLevel As Integer
    Public Property WindowsVersion As String
    Public Property WindowsRegionLanguage As String
    Public Property CurrentUserName As String
    Public Property CurrentUserType As String
    Public Property FocusedApplicationName As String
    Public Property RunningPrograms As List(Of String)
    Public Property InstalledPrograms As List(Of String)
End Class