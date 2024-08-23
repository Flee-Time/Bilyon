<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        ResetProgramButton = New Button()
        CloseButton = New Button()
        ApplyButton = New Button()
        QuitButton = New Button()
        SendFrequencyNUD = New NumericUpDown()
        InfoText = New Label()
        DefaultsButton = New Button()
        CType(SendFrequencyNUD, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ResetProgramButton
        ' 
        ResetProgramButton.Location = New Point(12, 65)
        ResetProgramButton.Name = "ResetProgramButton"
        ResetProgramButton.Size = New Size(120, 23)
        ResetProgramButton.TabIndex = 8
        ResetProgramButton.Text = "Programı Sıfırla"
        ResetProgramButton.UseVisualStyleBackColor = True
        ' 
        ' CloseButton
        ' 
        CloseButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        CloseButton.Location = New Point(12, 127)
        CloseButton.Name = "CloseButton"
        CloseButton.Size = New Size(75, 23)
        CloseButton.TabIndex = 7
        CloseButton.Text = "Kapat"
        CloseButton.UseVisualStyleBackColor = True
        ' 
        ' ApplyButton
        ' 
        ApplyButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ApplyButton.Location = New Point(189, 127)
        ApplyButton.Name = "ApplyButton"
        ApplyButton.Size = New Size(75, 23)
        ApplyButton.TabIndex = 6
        ApplyButton.Text = "Uygula"
        ApplyButton.UseVisualStyleBackColor = True
        ' 
        ' QuitButton
        ' 
        QuitButton.Location = New Point(12, 94)
        QuitButton.Name = "QuitButton"
        QuitButton.Size = New Size(120, 23)
        QuitButton.TabIndex = 10
        QuitButton.Text = "Uygulamayı Kapa"
        QuitButton.UseVisualStyleBackColor = True
        ' 
        ' SendFrequencyNUD
        ' 
        SendFrequencyNUD.Location = New Point(12, 34)
        SendFrequencyNUD.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        SendFrequencyNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        SendFrequencyNUD.Name = "SendFrequencyNUD"
        SendFrequencyNUD.Size = New Size(120, 23)
        SendFrequencyNUD.TabIndex = 12
        SendFrequencyNUD.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' InfoText
        ' 
        InfoText.AutoSize = True
        InfoText.Location = New Point(12, 16)
        InfoText.Name = "InfoText"
        InfoText.Size = New Size(171, 15)
        InfoText.TabIndex = 11
        InfoText.Text = "Bilgi Gönderme Aralığı (Saniye)"
        ' 
        ' DefaultsButton
        ' 
        DefaultsButton.Anchor = AnchorStyles.Bottom
        DefaultsButton.Location = New Point(102, 127)
        DefaultsButton.Name = "DefaultsButton"
        DefaultsButton.Size = New Size(75, 23)
        DefaultsButton.TabIndex = 13
        DefaultsButton.Text = "Varsayılan"
        DefaultsButton.UseVisualStyleBackColor = True
        ' 
        ' SettingsScreen
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(276, 162)
        Controls.Add(DefaultsButton)
        Controls.Add(SendFrequencyNUD)
        Controls.Add(InfoText)
        Controls.Add(QuitButton)
        Controls.Add(ResetProgramButton)
        Controls.Add(CloseButton)
        Controls.Add(ApplyButton)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "SettingsScreen"
        StartPosition = FormStartPosition.CenterParent
        Text = "Ayarlar"
        CType(SendFrequencyNUD, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ResetProgramButton As Button
    Friend WithEvents CloseButton As Button
    Friend WithEvents ApplyButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents SendFrequencyNUD As NumericUpDown
    Friend WithEvents InfoText As Label
    Friend WithEvents DefaultsButton As Button
End Class
