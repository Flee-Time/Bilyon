Imports System.ComponentModel
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Internal

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

    Private Sub DefaultsButton_Click(sender As Object, e As EventArgs) Handles DefaultsButton.Click
        PingFrequencyNUD.Value = 5
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
        ' Handle saving of settings

        Using db As New AppDbContext()
            Dim PingFreq = db.Settings.FirstOrDefault(Function(p) p.Setting = "PingFrequency")
            If PingFreq Is Nothing Then
                Dim pFreq As New Settings With {
                    .Setting = "PingFrequency",
                    .Value = Str(PingFrequencyNUD.Value)
                }
                db.Settings.Add(pFreq)
                db.SaveChanges()
            Else
                PingFreq.Value = Str(PingFrequencyNUD.Value)
                db.SaveChanges()
            End If
        End Using

        CloseForm()
    End Sub

    Private Sub SettingsScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Handle populating settings
        Using db As New AppDbContext()
            Dim PingFreq = db.Settings.FirstOrDefault(Function(p) p.Setting = "PingFrequency")
            If PingFreq Is Nothing Then
                PingFrequencyNUD.Value = 5
            Else
                PingFrequencyNUD.Value = Int(PingFreq.Value)
            End If
        End Using
    End Sub

    Private Sub ResetProgramButton_Click(sender As Object, e As EventArgs) Handles ResetProgramButton.Click
        Dim result As DialogResult = MessageBox.Show("Bunu yapmak istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim tableNames As New List(Of String)()

            Using db As New AppDbContext()
                Dim entityTypes = db.Model.GetEntityTypes()
                For Each entityType In entityTypes
                    Dim tableName = db.Model.FindEntityType(entityType.Name).GetTableName()
                    tableNames.Add(tableName)
                Next

                For Each tableName In tableNames
                    db.Database.ExecuteSqlRaw("DELETE FROM " + tableName + ";")
                Next
            End Using
            Application.Exit()
        End If
    End Sub
End Class