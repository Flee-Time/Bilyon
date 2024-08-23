Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class WebSocketClient
    Public Async Function PairServer(ServerIP As String, LocalIP As String, MacAdress As String, HostName As String) As Task(Of Boolean)
        Dim client As New TcpClient()
        Await client.ConnectAsync(ServerIP, 4201)

        Dim stream As NetworkStream = client.GetStream()

        Dim requestData As Byte() = Encoding.ASCII.GetBytes("PAIR_REQ")
        Await stream.WriteAsync(requestData, 0, requestData.Length)

        Dim buffer(client.ReceiveBufferSize) As Byte
        Dim bytesRead As Integer
        Dim responseData As New StringBuilder()

        Do
            bytesRead = Await stream.ReadAsync(buffer, 0, buffer.Length)
            responseData.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead))
        Loop While stream.DataAvailable

        Dim receivedData As JObject = JsonConvert.DeserializeObject(Of JObject)(responseData.ToString())
        Dim pairConf As String = receivedData.Property("PAIR_CONF").Value.ToString()
        Dim uniqueNumbers As String = pairConf.Substring(pairConf.Length - 6)

        Dim uniqueGuid As String = BilConMain.ClientGUID
        Dim regKeyPath As String = BilConMain.keyPath

        Dim responseJson As New With {
            .GUID = uniqueGuid,
            .PAIR_NUM = uniqueNumbers,
            .IP_ADDRESS = LocalIP,
            .MAC_ADDRESS = MacAdress,
            .HOST_NAME = HostName
        }
        Dim jsonResponse As String = JsonConvert.SerializeObject(responseJson)

        Dim responseDataBytes As Byte() = Encoding.ASCII.GetBytes(jsonResponse)
        Await stream.WriteAsync(responseDataBytes, 0, responseDataBytes.Length)

        client.Close()
        Return True
    End Function

    Public Async Function SendJSON(ServerIP As String, JsonText As String) As Task(Of Boolean)
        Dim client As New TcpClient()
        Try
            Await client.ConnectAsync(ServerIP, 4200)

            Dim stream As NetworkStream = client.GetStream()
            Dim jsonData As Byte() = Encoding.UTF8.GetBytes(JsonText)

            Await stream.WriteAsync(jsonData, 0, jsonData.Length)
            Await stream.FlushAsync()

            stream.Close()
            client.Close()

            Return True
        Catch ex As Exception
            My.Application.Log.WriteEntry("Error: " & ex.Message)
            Return False
        End Try
    End Function
End Class
