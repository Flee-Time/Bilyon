<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RamTile
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
        CapacityLabel = New Label()
        RamModelLabel = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CapacityLabel
        ' 
        CapacityLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        CapacityLabel.AutoSize = True
        CapacityLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        CapacityLabel.Location = New Point(154, 118)
        CapacityLabel.Name = "CapacityLabel"
        CapacityLabel.Size = New Size(109, 19)
        CapacityLabel.TabIndex = 9
        CapacityLabel.Text = "Kapasite: 16GB"
        ' 
        ' RamModelLabel
        ' 
        RamModelLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        RamModelLabel.Location = New Point(154, 12)
        RamModelLabel.Name = "RamModelLabel"
        RamModelLabel.Size = New Size(192, 80)
        RamModelLabel.TabIndex = 8
        RamModelLabel.Text = "RModel"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.ram
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(4, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(144, 144)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' RamTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(CapacityLabel)
        Controls.Add(RamModelLabel)
        Controls.Add(PictureBox1)
        Name = "RamTile"
        Size = New Size(350, 150)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CapacityLabel As Label
    Friend WithEvents RamModelLabel As Label
    Friend WithEvents PictureBox1 As PictureBox

End Class
