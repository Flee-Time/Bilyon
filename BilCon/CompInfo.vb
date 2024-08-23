Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Management
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.IO
Imports System.Security.Principal
Imports WindowsDisplayAPI
Imports System.Text.RegularExpressions

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

Public Class ComputerInfo
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

Public Class CompInfo
    Public Shared Function GetCompInfo(GUID As String) As ComputerInfo
        Dim Comp = New ComputerInfo()
        Comp.GUID = GUID
        Comp.CPUModel = GetCPUInfo()
        Comp.GPUModel = GetGPUModel()
        Comp.MotherboardModel = GetMotherboardModel()
        Comp.RAMDevice = GetRAMDevices()
        Comp.Drives = GetDrivesInfo()
        Comp.Screens = GetConnectedMonitors()
        Comp.BatteryDevice = GetBatteryInfo()
        Comp.NetworkInterfaces = GetNetworkInterfaces()
        Comp.CurrentUserName = GetCurrentUserName()
        Comp.CurrentUserType = GetCurrentUserType()
        Comp.FocusedApplicationName = GetFocusedApplicationName()
        Comp.InstalledPrograms = GetInstalledPrograms()
        Comp.RAMUtilization = GetRAMUtilization()
        Comp.RTCTime = GetRTCTime()
        Comp.RunningPrograms = GetRunningApplications()
        Comp.Uptime = GetSystemUptime()
        Comp.WindowsRegionLanguage = GetWindowsRegionLanguage()
        Comp.WindowsVersion = GetWindowsVersion()
        Return Comp
    End Function

    Private Shared Function GetCPUInfo() As CPU
        Dim cpuInfo As New CPU()
        ' Get CPU model and number of cores
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Processor")
        For Each queryObj As ManagementObject In searcher.Get()
            cpuInfo.Model = queryObj("Name").ToString()
            cpuInfo.Cores = Convert.ToInt32(queryObj("NumberOfCores"))
            Exit For ' Exit the loop after getting the first result
        Next
        ' Get CPU utilization
        Dim cpuCounter As New PerformanceCounter("Processor", "% Processor Time", "_Total")
        cpuCounter.NextValue() ' Call NextValue once to initialize the counter
        System.Threading.Thread.Sleep(250)
        cpuInfo.CPUUtilization = cpuCounter.NextValue()
        Return cpuInfo
    End Function

    Private Shared Function GetMotherboardModel() As String
        Dim motherboardModel As String = "Unknown"
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
        For Each queryObj As ManagementObject In searcher.Get()
            motherboardModel = queryObj("Product").ToString()
            Exit For ' Exit the loop after getting the first result
        Next
        Return motherboardModel
    End Function

    Private Shared Function GetRAMDevices() As List(Of RAM)
        Dim ramDevices As New List(Of RAM)()
        ' Get RAM model and capacity
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PhysicalMemory")
        For Each queryObj As ManagementObject In searcher.Get()
            Dim ramDevice As New RAM()
            ramDevice.Model = queryObj("PartNumber").ToString()
            ramDevice.Capacity = Convert.ToInt64(queryObj("Capacity")) / 1024 / 1024 & " MB"
            ramDevices.Add(ramDevice)
        Next
        Return ramDevices
    End Function

    Private Shared Function GetRAMUtilization() As Single
        ' Create a PerformanceCounter to measure available memory in megabytes
        Dim ramCounter As New PerformanceCounter("Memory", "Available MBytes")

        ' Read the current value
        Dim availableMemoryInMB As Single = ramCounter.NextValue()

        Return availableMemoryInMB
    End Function

    Private Shared Function GetGPUModel() As String
        Dim gpuModel As String = "Unknown"
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_VideoController")
        For Each queryObj As ManagementObject In searcher.Get()
            gpuModel = queryObj("Name").ToString()
            Exit For ' Exit the loop after getting the first result
        Next
        Return gpuModel
    End Function

    Private Shared Function GetDrivesInfo() As List(Of DriveInfo)
        Dim drives As New List(Of DriveInfo)()
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_LogicalDisk WHERE DriveType=3") ' DriveType=3 represents local disk drives

        For Each queryObj As ManagementObject In searcher.Get()
            Dim drive As New DriveInfo()
            drive.DriveLetter = queryObj("DeviceID").ToString()
            drive.FreeSpace = Convert.ToInt64(queryObj("FreeSpace"))
            drive.TotalSpace = Convert.ToInt64(queryObj("Size"))

            drives.Add(drive)
        Next

        Return drives
    End Function

    Public Shared Function GetConnectedMonitors() As List(Of Screen)
        Dim monitors As New List(Of Screen)()

        For Each monitor In DisplayConfig.PathDisplayTarget.GetDisplayTargets()
            Dim monitorInfo As New Screen()
            If monitor.FriendlyName IsNot String.Empty Then
                monitorInfo.Model = monitor.FriendlyName
            Else
                monitorInfo.Model = monitor.ToDisplayDevice.DeviceName
            End If
            monitorInfo.Resolution = $"{monitor.ToDisplayDevice.GetPreferredSetting.Resolution.Width}x{monitor.ToDisplayDevice.GetPreferredSetting.Resolution.Height}"
            monitorInfo.RefreshRate = $"{monitor.ToDisplayDevice.GetPreferredSetting.Frequency} Hz"
            monitors.Add(monitorInfo)
        Next

        Return monitors
    End Function

    Private Shared Function GetNetworkInterfaces() As List(Of NInterface)
        Dim interfaces As New List(Of NInterface)()
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_NetworkAdapter")

        For Each queryObj As ManagementObject In searcher.Get()
            Dim networkInterface As New NInterface()

            ' Check if MACAddress property is not null
            If queryObj("MACAddress") IsNot Nothing Then
                networkInterface.MacAddress = queryObj("MACAddress").ToString()
            Else
                Continue For
            End If

            networkInterface.Status = If(Convert.ToBoolean(queryObj("NetConnectionStatus")), "Connected", "Disconnected")

            Dim ipAddresses As String = ""
            If networkInterface.Status = "Connected" Then
                ' Convert InterfaceIndex to string before concatenating into query
                Dim interfaceIndex As String = queryObj("InterfaceIndex").ToString()
                Dim query As String = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE InterfaceIndex='" + interfaceIndex + "'"
                Dim searcherIP As New ManagementObjectSearcher("root\CIMV2", query)
                For Each ipObj As ManagementObject In searcherIP.Get()
                    If ipObj("IPAddress") IsNot Nothing AndAlso CType(ipObj("IPAddress"), String()).Length > 0 Then
                        ipAddresses = String.Join(", ", CType(ipObj("IPAddress"), String()))
                    End If
                Next
            Else
                ipAddresses = "-"
            End If
            networkInterface.IPAddress = ipAddresses

            interfaces.Add(networkInterface)
        Next

        Return interfaces
    End Function

    Private Shared Function GetBatteryInfo() As Battery
        Dim batteryInfo As New Battery()

        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Battery")

        If searcher.Get().Count > 0 Then
            For Each queryObj As ManagementObject In searcher.Get()
                batteryInfo.BatteryStatus = If(Convert.ToInt32(queryObj("BatteryStatus")) = 1, "Discharging", "Charging")
                batteryInfo.BatteryLevel = If(queryObj("EstimatedChargeRemaining") IsNot Nothing, Convert.ToInt32(queryObj("EstimatedChargeRemaining")), -1)
            Next
        Else
            batteryInfo.BatteryStatus = "No Battery"
            batteryInfo.BatteryLevel = -1
        End If

        Return batteryInfo
    End Function

    Private Shared Function GetInstalledPrograms() As List(Of String)
        Dim installedPrograms As New List(Of String)()

        ' Registry key where installed programs are registered
        Dim uninstallKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"

        ' Open the uninstall registry key
        Using uninstallKey As RegistryKey = Registry.LocalMachine.OpenSubKey(uninstallKeyPath)
            If uninstallKey IsNot Nothing Then
                ' Get all subkey names (each subkey represents an installed program)
                For Each subKeyName As String In uninstallKey.GetSubKeyNames()
                    ' Open each subkey to read program information
                    Using programKey As RegistryKey = uninstallKey.OpenSubKey(subKeyName)
                        If programKey IsNot Nothing Then
                            ' Read the display name of the program
                            Dim displayName As Object = programKey.GetValue("DisplayName")
                            If displayName IsNot Nothing AndAlso TypeOf displayName Is String Then
                                ' Add the display name to the list of installed programs
                                installedPrograms.Add(CStr(displayName))
                            End If
                        End If
                    End Using
                Next
            End If
        End Using

        Return installedPrograms
    End Function

    Private Shared Function GetSystemUptime() As TimeSpan
        Dim searcher As New ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem")
        Dim bootUpTime As DateTime = DateTime.MinValue

        For Each queryObj As ManagementObject In searcher.Get()
            Dim lastBootUpTime As String = queryObj("LastBootUpTime").ToString()
            bootUpTime = ManagementDateTimeConverter.ToDateTime(lastBootUpTime)
            Exit For ' We only need one result
        Next

        If bootUpTime <> DateTime.MinValue Then
            Return DateTime.Now - bootUpTime
        Else
            Return TimeSpan.Zero ' Unable to retrieve the system uptime
        End If
    End Function

    Private Shared Function GetRTCTime() As DateTime
        ' Get the current local date and time
        Return DateTime.Now
    End Function

    Private Shared Function GetWindowsVersion() As String
        Try
            Dim regKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
            If regKey IsNot Nothing Then
                Dim productName As String = regKey.GetValue("ProductName").ToString()
                Dim displayVersion As String = regKey.GetValue("DisplayVersion").ToString()
                ' Construct the Windows version string
                Dim windowsVersionString As String = productName + " " + displayVersion
                Return windowsVersionString
            Else
                Return "Unknown"
            End If
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

    Private Shared Function GetWindowsRegionLanguage() As String
        Try
            ' Get the current culture info
            Dim currentCulture As CultureInfo = CultureInfo.CurrentCulture
            ' Construct the Windows region and language string
            Dim regionLanguageString As String = currentCulture.DisplayName
            Return regionLanguageString
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

    Private Shared Function GetCurrentUserName() As String
        ' Get the current user's username
        Return Environment.UserName
    End Function

    Private Shared Function GetCurrentUserType() As String
        Try
            ' Get the current user's Windows identity
            Dim currentUser As WindowsIdentity = WindowsIdentity.GetCurrent()
            If currentUser IsNot Nothing AndAlso currentUser.User IsNot Nothing Then
                ' Check if the user's SID starts with "S-1-5-21-" which indicates a Microsoft account (online account)
                If currentUser.User.ToString().StartsWith("S-1-5-21-") Then
                    Return "Online (Microsoft) Account"
                Else
                    Return "Local Account"
                End If
            Else
                Return "Unknown"
            End If
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

    Private Shared Function GetFocusedApplicationName() As String
        Try
            Dim handle As IntPtr = GetForegroundWindow()
            Dim length As Integer = GetWindowTextLength(handle)
            Dim stringBuilder As New System.Text.StringBuilder(length + 1)

            If GetWindowText(handle, stringBuilder, stringBuilder.Capacity) > 0 Then
                Return stringBuilder.ToString()
            Else
                Return "Unknown"
            End If
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr

    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (
        ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (
        ByVal hwnd As IntPtr) As Integer

    Private Shared Function GetRunningApplications() As List(Of String)
        Dim runningApps As New List(Of String)

        ' Get all running processes
        Dim processes As Process() = Process.GetProcesses()

        ' Iterate through each process and add the main window title if it exists
        For Each proc As Process In processes
            If Not String.IsNullOrEmpty(proc.MainWindowTitle) AndAlso Not proc.ProcessName.Equals("Idle") Then
                runningApps.Add(proc.MainWindowTitle)
            End If
        Next

        Return runningApps
    End Function
End Class