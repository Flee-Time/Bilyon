Imports System.IO
Imports System.Net.Sockets
Imports Newtonsoft.Json
Imports System.Text

Public Class TcpFileSender

    Public Sub SendFile(ipAddress As String, port As Integer)
        Try
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Select File to Send"
            openFileDialog.Filter = "All files (*.*)|*.*"
            openFileDialog.Multiselect = False

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName
                Dim client As New TcpClient(ipAddress, port)
                Dim stream As NetworkStream = client.GetStream()

                Dim filebuffer As Byte()
                Dim fileStream As Stream
                Try
                    fileStream = File.OpenRead(filePath)
                    ReDim filebuffer(fileStream.Length)

                    Dim fileInfo As New With {.FileName = Path.GetFileName(filePath), .BufferSize = fileStream.Length}
                    Dim json As String = JsonConvert.SerializeObject(fileInfo)
                    Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(json)
                    stream.Write(jsonBytes, 0, jsonBytes.Length)

                    Dim acknowledgmentBuffer(1024) As Byte
                    Dim bytesRead As Integer = stream.Read(acknowledgmentBuffer, 0, acknowledgmentBuffer.Length)
                    Dim ackClient = Encoding.UTF8.GetString(acknowledgmentBuffer, 0, bytesRead)

                    If ackClient = "ACK_START" Then
                        My.Application.Log.WriteEntry("ACK_START recieved, starting sending.")
                        Try
                            fileStream.Read(filebuffer, 0, fileStream.Length)
                            stream.Write(filebuffer, 0, fileStream.Length)
                        Catch ex As Exception
                            My.Application.Log.WriteEntry($"Error: {ex.Message}")
                        End Try
                    End If
                Catch ex As Exception
                    My.Application.Log.WriteEntry($"Error: {ex.Message}")
                End Try

                stream.Close()
                client.Close()
                MessageBox.Show("Dosya başarıyla gönderildi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class