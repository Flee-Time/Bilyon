Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Security.Principal
Imports NetFwTypeLib

Public Class Extentions
    Public Shared Function IsValidIP(ByVal ipAddress As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(ipAddress,
          "^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$")
    End Function

    Public Shared Async Function PingHost(ipAddress As String) As Task(Of Boolean)
        Try
            Dim pingSender As New Ping()
            Dim reply As PingReply = Await pingSender.SendPingAsync(ipAddress)
            If reply.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetLocalIPAddress() As String
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())

        For Each ip As IPAddress In hostEntry.AddressList
            If ip.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                Return ip.ToString()
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function GetMacAddress() As String
        Dim macAddress As String = ""
        Dim interfaces() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()

        For Each networkInterface As NetworkInterface In interfaces
            If networkInterface.OperationalStatus = OperationalStatus.Up AndAlso
               networkInterface.NetworkInterfaceType <> NetworkInterfaceType.Loopback AndAlso
               networkInterface.NetworkInterfaceType <> NetworkInterfaceType.Tunnel Then

                macAddress = networkInterface.GetPhysicalAddress().ToString()
                Exit For
            End If
        Next

        Return macAddress
    End Function

    Public Shared Function AddPortRule(ByVal port As Integer, ByVal name As String, ByVal description As String, ByVal direction As NET_FW_RULE_DIRECTION_)
        Try
            Dim firewallPolicy As INetFwPolicy2 = DirectCast(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")), INetFwPolicy2)
            Dim firewallRule As INetFwRule = DirectCast(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")), INetFwRule)

            firewallRule.Name = name
            firewallRule.Description = description
            firewallRule.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP
            firewallRule.LocalPorts = port.ToString()
            firewallRule.Direction = direction
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW
            firewallRule.Enabled = True

            firewallPolicy.Rules.Add(firewallRule)
            Return True
        Catch ex As Exception
            My.Application.Log.WriteEntry("Error when adding firewall rules. Error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function RuleExists(ByVal ruleName As String) As Boolean
        Dim firewallPolicy As INetFwPolicy2 = DirectCast(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")), INetFwPolicy2)
        Try
            Dim rule As INetFwRule = firewallPolicy.Rules.Item(ruleName)
            If rule IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function IsAdmin() As Boolean
        Dim principal As New WindowsPrincipal(WindowsIdentity.GetCurrent())
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Shared Function IsAppAlreadyRunning() As Boolean
        Dim currentProcess As Process = Process.GetCurrentProcess()
        Dim processesByName As Process() = Process.GetProcessesByName(currentProcess.ProcessName)

        ' Check if there's another instance of the application running
        Return processesByName.Length > 1
    End Function
End Class
