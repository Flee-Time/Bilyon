Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

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

    Public Shared Function FormatElapsedTime(elapsedTime As TimeSpan) As String
        Dim days As Integer = elapsedTime.Days
        Dim hours As Integer = elapsedTime.Hours
        Dim minutes As Integer = elapsedTime.Minutes

        Dim formattedTime As String = ""

        If days > 0 Then
            formattedTime &= days.ToString() & "g"
            formattedTime &= " "
        End If

        If hours > 0 Then
            formattedTime &= hours.ToString() & "s"
            formattedTime &= " "
        End If

        If minutes > 0 Then
            formattedTime &= minutes.ToString() & "d"
            formattedTime &= " "
        End If

        If formattedTime = "" Then
            formattedTime = "şimdi"
        End If

        Return formattedTime
    End Function

    Public Shared Function GetLocalIPAddress() As String
        Dim localIP As String

        Using Socket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)
            Socket.Connect("8.8.8.8", 65530)
            Dim EndPoint As IPEndPoint = Socket.LocalEndPoint
            localIP = EndPoint.Address.ToString()
        End Using

        If localIP IsNot String.Empty Then
            Return localIP
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function FormatMacAddress(macAddress As String) As String
        Dim formattedMacAddress As String = ""

        For i As Integer = 0 To macAddress.Length - 1 Step 2
            If i + 1 < macAddress.Length Then
                formattedMacAddress += macAddress.Substring(i, 2) + ":"
            Else
                formattedMacAddress += macAddress.Substring(i, 2)
            End If
        Next

        If formattedMacAddress.EndsWith(":") Then
            formattedMacAddress = formattedMacAddress.Remove(formattedMacAddress.Length - 1)
        End If

        Return formattedMacAddress
    End Function
End Class
