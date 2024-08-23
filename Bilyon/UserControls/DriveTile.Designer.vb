<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DriveTile
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
        FreeSpaceLabel = New Label()
        TotalSpaceLabel = New Label()
        PictureBox1 = New PictureBox()
        DriveLetterLabel = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FreeSpaceLabel
        ' 
        FreeSpaceLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        FreeSpaceLabel.AutoSize = True
        FreeSpaceLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        FreeSpaceLabel.Location = New Point(167, 128)
        FreeSpaceLabel.Name = "FreeSpaceLabel"
        FreeSpaceLabel.Size = New Size(80, 19)
        FreeSpaceLabel.TabIndex = 10
        FreeSpaceLabel.Text = "214.564GB"
        ' 
        ' TotalSpaceLabel
        ' 
        TotalSpaceLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalSpaceLabel.AutoSize = True
        TotalSpaceLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        TotalSpaceLabel.Location = New Point(167, 90)
        TotalSpaceLabel.Name = "TotalSpaceLabel"
        TotalSpaceLabel.Size = New Size(52, 19)
        TotalSpaceLabel.TabIndex = 9
        TotalSpaceLabel.Text = "512GB"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.hdd
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(4, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(144, 144)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' DriveLetterLabel
        ' 
        DriveLetterLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        DriveLetterLabel.AutoSize = True
        DriveLetterLabel.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        DriveLetterLabel.Location = New Point(167, 22)
        DriveLetterLabel.Name = "DriveLetterLabel"
        DriveLetterLabel.Size = New Size(29, 28)
        DriveLetterLabel.TabIndex = 11
        DriveLetterLabel.Text = "C:"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(154, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(42, 19)
        Label1.TabIndex = 12
        Label1.Text = "Disk:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(154, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(174, 19)
        Label2.TabIndex = 13
        Label2.Text = "Toplam Depolama Alanı:"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(154, 109)
        Label3.Name = "Label3"
        Label3.Size = New Size(148, 19)
        Label3.TabIndex = 14
        Label3.Text = "Boş Depolama Alanı:"
        ' 
        ' DriveTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DriveLetterLabel)
        Controls.Add(FreeSpaceLabel)
        Controls.Add(TotalSpaceLabel)
        Controls.Add(PictureBox1)
        Name = "DriveTile"
        Size = New Size(350, 150)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FreeSpaceLabel As Label
    Friend WithEvents TotalSpaceLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DriveLetterLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label

End Class
