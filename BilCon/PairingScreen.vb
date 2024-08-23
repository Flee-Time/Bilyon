Imports System.Net
Imports BilCon.Extentions
Imports Microsoft.SqlServer
Imports Microsoft.Win32

Public Class PairingScreen
    Private Shared _instance As New PairingScreen
    Public Shared ReadOnly Property Instance() As PairingScreen
        Get
            Return _instance
        End Get
    End Property

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        Me.LoadingPicture.Visible = False
        Me.ConnectButton.Enabled = True
        e.Cancel = True
        CloseForm()
    End Sub

    Private Sub CloseForm()
        Me.Hide()
    End Sub

    Private Async Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        If IsValidIP(IPTextBox.Text) Then
            Me.LoadingPicture.Visible = True
            Me.ConnectButton.Enabled = False
            Try
                If Await BilConMain.Instance.client.PairServer(IPTextBox.Text, GetLocalIPAddress(), GetMacAddress(), Dns.GetHostName()) Then
                    Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(BilConMain.keyPath, True)
                    If regKey IsNot Nothing Then
                        regKey.SetValue("serverIP", IPTextBox.Text, RegistryValueKind.String)
                        regKey.Close()
                    End If
                    CloseForm()
                End If
            Catch ex As Exception
                MessageBox.Show("Beklenmeyen hata. Error: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.LoadingPicture.Visible = False
                Me.ConnectButton.Enabled = True
            End Try
        Else
            MessageBox.Show("Yanlış IP girişi yaptınız. Tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class