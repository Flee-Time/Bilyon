Imports Microsoft.Win32

Public Class SettingsScreen
    Inherits System.Windows.Forms.Form

    Private Shared _instance As New SettingsScreen
    Public Shared ReadOnly Property Instance() As SettingsScreen
        Get
            Return _instance
        End Get
    End Property

    Private Sub CloseForm()
        Me.Hide()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        CloseForm()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        CloseForm()
    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        Application.Exit()
    End Sub

    Private Sub DefaultsButton_Click(sender As Object, e As EventArgs) Handles DefaultsButton.Click
        SendFrequencyNUD.Value = 5
    End Sub

    Private Sub ResetProgramButton_Click(sender As Object, e As EventArgs) Handles ResetProgramButton.Click
        Dim result As DialogResult = MessageBox.Show("Bunu yapmak istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            BilConMain.Instance.DeleteRegs()
            Application.Exit()
        End If
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
        Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(BilConMain.Instance.keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
        regKey.SetValue("sendFrequency", Str(SendFrequencyNUD.Value * 1000), RegistryValueKind.String)
        regKey.Close()

        CloseForm()
    End Sub

    Private Sub SettingsScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(BilConMain.Instance.keyPath)

        If regKey IsNot Nothing Then
            Dim regFreq As Object = regKey.GetValue("sendFrequency")
            SendFrequencyNUD.Value = If(regFreq IsNot Nothing, CInt(regFreq.ToString()) / 1000, 5)
        End If
    End Sub
End Class