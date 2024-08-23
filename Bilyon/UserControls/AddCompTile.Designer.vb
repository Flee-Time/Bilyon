<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCompTile
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        InfoLabel = New Label()
        AddCompButton = New Button()
        SuspendLayout()
        ' 
        ' InfoLabel
        ' 
        InfoLabel.AutoSize = True
        InfoLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        InfoLabel.Location = New Point(24, 20)
        InfoLabel.Name = "InfoLabel"
        InfoLabel.Size = New Size(121, 21)
        InfoLabel.TabIndex = 0
        InfoLabel.Text = "Bilgisayar Ekle"
        ' 
        ' AddCompButton
        ' 
        AddCompButton.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        AddCompButton.Location = New Point(47, 65)
        AddCompButton.Name = "AddCompButton"
        AddCompButton.Size = New Size(75, 28)
        AddCompButton.TabIndex = 1
        AddCompButton.Text = "Ekle"
        AddCompButton.UseVisualStyleBackColor = True
        ' 
        ' AddCompTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(AddCompButton)
        Controls.Add(InfoLabel)
        Name = "AddCompTile"
        Size = New Size(175, 112)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents InfoLabel As Label
    Friend WithEvents AddCompButton As Button

End Class
