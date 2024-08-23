<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenTile
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
        PictureBox1 = New PictureBox()
        ScreenModelLabel = New Label()
        ResolutionLabel = New Label()
        RefreshRateLabel = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.pc_icon
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(144, 144)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' ScreenModelLabel
        ' 
        ScreenModelLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        ScreenModelLabel.Location = New Point(153, 12)
        ScreenModelLabel.Name = "ScreenModelLabel"
        ScreenModelLabel.Size = New Size(192, 80)
        ScreenModelLabel.TabIndex = 4
        ScreenModelLabel.Text = "SModel"
        ' 
        ' ResolutionLabel
        ' 
        ResolutionLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ResolutionLabel.AutoSize = True
        ResolutionLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ResolutionLabel.Location = New Point(153, 103)
        ResolutionLabel.Name = "ResolutionLabel"
        ResolutionLabel.Size = New Size(165, 19)
        ResolutionLabel.TabIndex = 5
        ResolutionLabel.Text = "Çözünürlük: 2560x1080"
        ' 
        ' RefreshRateLabel
        ' 
        RefreshRateLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        RefreshRateLabel.AutoSize = True
        RefreshRateLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        RefreshRateLabel.Location = New Point(153, 123)
        RefreshRateLabel.Name = "RefreshRateLabel"
        RefreshRateLabel.Size = New Size(150, 19)
        RefreshRateLabel.TabIndex = 6
        RefreshRateLabel.Text = "Yenileme Hızı: 165Hz"
        ' 
        ' ScreenTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(RefreshRateLabel)
        Controls.Add(ResolutionLabel)
        Controls.Add(ScreenModelLabel)
        Controls.Add(PictureBox1)
        Name = "ScreenTile"
        Size = New Size(350, 150)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ScreenModelLabel As Label
    Friend WithEvents ResolutionLabel As Label
    Friend WithEvents RefreshRateLabel As Label

End Class
