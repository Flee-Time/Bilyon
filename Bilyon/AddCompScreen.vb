Imports Bilyon.Extentions
Public Class AddCompScreen
    Inherits System.Windows.Forms.Form
    Private gResult As Boolean = False

    Private Shared _instance As New AddCompScreen
    Public Shared ReadOnly Property Instance() As AddCompScreen
        Get
            Return _instance
        End Get
    End Property
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        CloseForm()
    End Sub

    Private Sub CloseForm()
        Me.LoadingPicture.Visible = False
        Me.ConnectButton.Enabled = True
        Me.IPLabel.Text = Nothing
        gResult = False
        CheckerTimer.Enabled = False
        Me.Hide()
    End Sub

    Private Async Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Me.LoadingPicture.Visible = True
        Me.ConnectButton.Enabled = False
        Try
            MainScreen.Instance.server.SetPairing(True)
            gResult = Await MainScreen.Instance.server.StartPairingAsync()
        Catch ex As Exception
            MessageBox.Show("Beklenmeyen hata. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.LoadingPicture.Visible = False
            Me.ConnectButton.Enabled = True
        End Try
    End Sub

    Private Sub AddCompScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.IPLabel.Text = GetLocalIPAddress()
        CheckerTimer.Enabled = True
    End Sub

    Private Sub CheckerTimer_Tick(sender As Object, e As EventArgs) Handles CheckerTimer.Tick
        If gResult Then
            MainScreen.Instance.UpdateFlow()
            CloseForm()
        End If
    End Sub
End Class