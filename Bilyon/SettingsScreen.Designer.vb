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
        ApplyButton = New Button()
        CloseButton = New Button()
        Label1 = New Label()
        PingFrequencyNUD = New NumericUpDown()
        DefaultsButton = New Button()
        ResetProgramButton = New Button()
        CType(PingFrequencyNUD, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ApplyButton
        ' 
        ApplyButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ApplyButton.Location = New Point(206, 91)
        ApplyButton.Name = "ApplyButton"
        ApplyButton.Size = New Size(75, 23)
        ApplyButton.TabIndex = 0
        ApplyButton.Text = "Uygula"
        ApplyButton.UseVisualStyleBackColor = True
        ' 
        ' CloseButton
        ' 
        CloseButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        CloseButton.Location = New Point(12, 91)
        CloseButton.Name = "CloseButton"
        CloseButton.Size = New Size(75, 23)
        CloseButton.TabIndex = 1
        CloseButton.Text = "Kapat"
        CloseButton.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 15)
        Label1.TabIndex = 2
        Label1.Text = "Ping Atma Aralığı (Saniye)"
        ' 
        ' PingFrequencyNUD
        ' 
        PingFrequencyNUD.Location = New Point(12, 27)
        PingFrequencyNUD.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        PingFrequencyNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        PingFrequencyNUD.Name = "PingFrequencyNUD"
        PingFrequencyNUD.Size = New Size(120, 23)
        PingFrequencyNUD.TabIndex = 3
        PingFrequencyNUD.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' DefaultsButton
        ' 
        DefaultsButton.Anchor = AnchorStyles.Bottom
        DefaultsButton.Location = New Point(109, 91)
        DefaultsButton.Name = "DefaultsButton"
        DefaultsButton.Size = New Size(75, 23)
        DefaultsButton.TabIndex = 4
        DefaultsButton.Text = "Varsayılan"
        DefaultsButton.UseVisualStyleBackColor = True
        ' 
        ' ResetProgramButton
        ' 
        ResetProgramButton.Location = New Point(12, 58)
        ResetProgramButton.Name = "ResetProgramButton"
        ResetProgramButton.Size = New Size(120, 23)
        ResetProgramButton.TabIndex = 9
        ResetProgramButton.Text = "Programı Sıfırla"
        ResetProgramButton.UseVisualStyleBackColor = True
        ' 
        ' SettingsScreen
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(293, 126)
        Controls.Add(ResetProgramButton)
        Controls.Add(DefaultsButton)
        Controls.Add(PingFrequencyNUD)
        Controls.Add(Label1)
        Controls.Add(CloseButton)
        Controls.Add(ApplyButton)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "SettingsScreen"
        StartPosition = FormStartPosition.CenterParent
        Text = "Ayarlar"
        CType(PingFrequencyNUD, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ApplyButton As Button
    Friend WithEvents CloseButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PingFrequencyNUD As NumericUpDown
    Friend WithEvents DefaultsButton As Button
    Friend WithEvents ResetProgramButton As Button
End Class
