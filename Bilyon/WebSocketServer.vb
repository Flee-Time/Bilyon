Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.EntityFrameworkCore
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class WebSocketServer
    Private listener As TcpListener
    Private pairingListener As TcpListener
    Private inPairing As Boolean

    Public Sub New()
        inPairing = False
        listener = New TcpListener(IPAddress.Any, 4200)
        listener.Start()
        pairingListener = New TcpListener(IPAddress.Any, 4201)
        pairingListener.Start()
        My.Application.Log.WriteEntry("Server started. Waiting for connections...")
    End Sub

    Public Sub SetPairing(value As Boolean)
        inPairing = value
    End Sub

    Public Async Function StartListeningAsync() As Task
        While True
            Dim client = Await listener.AcceptTcpClientAsync()
            Await HandleClientAsync(client)
        End While
    End Function

    Public Async Function StartPairingAsync() As Task(Of Boolean)
        While True
            Dim pairingClient = Await pairingListener.AcceptTcpClientAsync()
            Return Await HandleClientPairingAsync(pairingClient)
        End While
    End Function

    Private Async Function HandleClientPairingAsync(client As TcpClient) As Task(Of Boolean)
        Dim stream = client.GetStream()
        Dim buffer(client.ReceiveBufferSize) As Byte
        Dim data As String
        Dim bytesRead As Integer

        While True
            bytesRead = Await stream.ReadAsync(buffer, 0, buffer.Length)
            data = Encoding.ASCII.GetString(buffer, 0, bytesRead)
            My.Application.Log.WriteEntry("Received: " & data)

            If inPairing AndAlso data.Trim().ToUpper() = "PAIR_REQ" Then
                Dim random As New Random()
                Dim digits As New List(Of Integer)
                While digits.Count < 6
                    Dim digit = random.Next(0, 10)
                    If Not digits.Contains(digit) Then
                        digits.Add(digit)
                    End If
                End While
                Dim pairConfJson As New With {.PAIR_CONF = String.Join("", digits)}

                Dim jsonPairConf As String = JsonConvert.SerializeObject(pairConfJson)
                Dim responseData As Byte() = Encoding.ASCII.GetBytes(jsonPairConf)
                Await stream.WriteAsync(responseData, 0, responseData.Length)

                Dim jsonBuffer As New StringBuilder()
                Do
                    bytesRead = Await stream.ReadAsync(buffer, 0, buffer.Length)
                    jsonBuffer.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead))
                Loop While stream.DataAvailable

                Dim receivedData As String = jsonBuffer.ToString()
                Dim receivedPairNum As JObject = JsonConvert.DeserializeObject(Of JObject)(receivedData)
                Dim pairNum As String = receivedPairNum.Property("PAIR_NUM").Value.ToString()

                If pairNum = pairConfJson.PAIR_CONF Then
                    Dim ip_address As String = receivedPairNum.Property("IP_ADDRESS").Value.ToString()
                    Dim mac_address As String = receivedPairNum.Property("MAC_ADDRESS").Value.ToString()
                    Dim host_name As String = receivedPairNum.Property("HOST_NAME").Value.ToString()
                    Dim guid As String = receivedPairNum.Property("GUID").Value.ToString()

                    Using db As New AppDbContext()
                        Dim Computer = db.Computers.FirstOrDefault(Function(p) p.Mac_Adress = mac_address)
                        If Computer Is Nothing Then
                            Dim NewComp As New Computers With {
                                .GUID = guid,
                                .Local_Ip = ip_address,
                                .Mac_Adress = mac_address,
                                .Host_Name = host_name
                            }
                            db.Computers.Add(NewComp)
                            db.SaveChanges()
                            My.Application.Log.WriteEntry("Pairing successfull with " + host_name + ".")
                            Return True
                        Else
                            My.Application.Log.WriteEntry("The computer " + host_name + " is already added.")
                            Throw New System.Exception("The computer is already added.")
                        End If
                    End Using
                Else
                    My.Application.Log.WriteEntry("PAIR_NUM: " + pairNum + ", CLIENT_PAIR_NUM: " + pairConfJson.PAIR_CONF + " / Mismatch, try again.")
                    Throw New System.Exception("PAIR_NUM mismatch, try again.")
                End If
            End If
        End While
    End Function

    Private Async Function HandleClientAsync(client As TcpClient) As Task
        Try
            Dim data As Byte() = New Byte(32768) {}
            Dim stream As NetworkStream = client.GetStream()
            Dim bytesRead As Integer = Await stream.ReadAsync(data, 0, data.Length)
            Dim receivedJson As String = Encoding.UTF8.GetString(data, 0, bytesRead)

            Dim computerInfo As CompInfo = JsonConvert.DeserializeObject(Of CompInfo)(receivedJson)

            client.Close()

            Try
                If computerInfo IsNot Nothing Then
                    Dim compDetail As New CompDetail()
                    With compDetail
                        .GUID = computerInfo.GUID
                        .CPU_Model = computerInfo.CPUModel.Model
                        .CPU_Cores = computerInfo.CPUModel.Cores.ToString()
                        .CPU_Util = computerInfo.CPUModel.CPUUtilization.ToString()
                        .MotherboardModel = computerInfo.MotherboardModel
                        .RAMDevice = computerInfo.RAMDevice.Select(Function(ram) JsonConvert.SerializeObject(ram)).ToList()
                        .RAMUtilization = computerInfo.RAMUtilization
                        .GPUModel = computerInfo.GPUModel
                        .Drives = computerInfo.Drives.Select(Function(drive) JsonConvert.SerializeObject(drive)).ToList()
                        .Screens = computerInfo.Screens.Select(Function(screen) JsonConvert.SerializeObject(screen)).ToList()
                        .NetworkInterfaces = computerInfo.NetworkInterfaces.Select(Function(nInterface) JsonConvert.SerializeObject(nInterface)).ToList()
                        .Uptime = computerInfo.Uptime
                        .RTCTime = computerInfo.RTCTime
                        .BatteryStatus = computerInfo.BatteryDevice.BatteryStatus
                        .BatteryLevel = computerInfo.BatteryDevice.BatteryLevel
                        .WindowsVersion = computerInfo.WindowsVersion
                        .WindowsRegionLanguage = computerInfo.WindowsRegionLanguage
                        .CurrentUserName = computerInfo.CurrentUserName
                        .CurrentUserType = computerInfo.CurrentUserType
                        .FocusedApplicationName = computerInfo.FocusedApplicationName
                        .RunningPrograms = computerInfo.RunningPrograms
                        .InstalledPrograms = computerInfo.InstalledPrograms
                    End With

                    Using db As New AppDbContext()
                        Dim existingRecord = db.CompDetail.FirstOrDefault(Function(c) c.GUID = compDetail.GUID)

                        If existingRecord IsNot Nothing Then
                            existingRecord.CPU_Model = compDetail.CPU_Model
                            existingRecord.CPU_Cores = compDetail.CPU_Cores
                            existingRecord.CPU_Util = compDetail.CPU_Util
                            existingRecord.MotherboardModel = compDetail.MotherboardModel
                            existingRecord.RAMDevice = compDetail.RAMDevice
                            existingRecord.RAMUtilization = compDetail.RAMUtilization
                            existingRecord.GPUModel = compDetail.GPUModel
                            existingRecord.Drives = compDetail.Drives
                            existingRecord.Screens = compDetail.Screens
                            existingRecord.NetworkInterfaces = compDetail.NetworkInterfaces
                            existingRecord.Uptime = compDetail.Uptime
                            existingRecord.RTCTime = compDetail.RTCTime
                            existingRecord.BatteryStatus = compDetail.BatteryStatus
                            existingRecord.BatteryLevel = compDetail.BatteryLevel
                            existingRecord.WindowsVersion = compDetail.WindowsVersion
                            existingRecord.WindowsRegionLanguage = compDetail.WindowsRegionLanguage
                            existingRecord.CurrentUserName = compDetail.CurrentUserName
                            existingRecord.CurrentUserType = compDetail.CurrentUserType
                            existingRecord.FocusedApplicationName = compDetail.FocusedApplicationName
                            existingRecord.RunningPrograms = compDetail.RunningPrograms
                            existingRecord.InstalledPrograms = compDetail.InstalledPrograms
                        Else
                            db.CompDetail.Add(compDetail)
                        End If

                        db.SaveChanges()
                    End Using
                End If
            Catch ex As Exception
                My.Application.Log.WriteEntry("Error writing CompInfo to database: " & ex.Message)
            End Try
        Catch ex As Exception
            My.Application.Log.WriteEntry("Error parsing JSON: " & ex.Message)
        End Try
    End Function
End Class
