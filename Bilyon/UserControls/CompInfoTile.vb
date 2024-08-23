Imports System.Net.NetworkInformation
Imports Bilyon.Extentions

Public Class CompInfoTile
    Private Computer As Computers
    Private lastSuccessfulPingTime As DateTime = DateTime.MinValue
    Private frequency As Integer

    Public Sub SetValues(ByVal _computer As Computers)
        Computer = _computer
        CompNameLabel.Text = Computer.Host_Name
        IPLabel.Text = "IP: " + Computer.Local_Ip
        Using db As New AppDbContext()
            Dim PingFreq = db.Settings.FirstOrDefault(Function(p) p.Setting = "PingFrequency")
            If PingFreq Is Nothing Then
                frequency = 5000 'ms
            Else
                frequency = PingFreq.Value * 1000 's
            End If
            Dim LastRecord = db.LastSeen.FirstOrDefault(Function(p) p.COMP_GUID = Computer.GUID)
            If LastRecord Is Nothing Then
                lastSuccessfulPingTime = DateTime.Now
            Else
                lastSuccessfulPingTime = LastRecord.LastSeenTime
            End If
        End Using
        UpdateTimer.Interval = frequency
        UpdateTimer.Enabled = True
        Update_Info()
    End Sub

    Private Async Sub Update_Info()
        If Await PingHost(Computer.Local_Ip) Then
            StatusPictureBox.Image = My.Resources.pc_icon
            StatusLabel.Text = "Durum: Çevrimiçi"
            lastSuccessfulPingTime = DateTime.Now
            Me.BackColor = Color.LightGreen
            UpdateElapsedTime()
        Else
            StatusPictureBox.Image = My.Resources.x_icon
            StatusLabel.Text = "Durum: Çevrimdışı"
            Me.BackColor = Color.LightCoral
            UpdateElapsedTime()
        End If
    End Sub

    Private Sub UpdateElapsedTime()
        Dim elapsedTime As TimeSpan = DateTime.Now - lastSuccessfulPingTime
        Dim formattedTime As String = FormatElapsedTime(elapsedTime)
        LastSeenLabel.Text = "Son Görülme: " + formattedTime
        Using db As New AppDbContext()
            Dim LastRecord = db.LastSeen.FirstOrDefault(Function(p) p.COMP_GUID = Computer.GUID)
            If LastRecord Is Nothing Then
                Dim createRecord As New LastSeen With {
                    .COMP_GUID = Computer.GUID,
                    .LastSeenTime = DateTime.Now
                }
                db.LastSeen.Add(createRecord)
                db.SaveChanges()
            Else
                LastRecord.LastSeenTime = lastSuccessfulPingTime
                db.SaveChanges()
            End If
        End Using
    End Sub

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        Update_Info()
    End Sub

    Private Sub InfoButton_Click(sender As Object, e As EventArgs) Handles InfoButton.Click
        ComputerInfo.Instance.CompGUID = Computer.GUID
        ComputerInfo.Instance.ShowDialog()
    End Sub
End Class
