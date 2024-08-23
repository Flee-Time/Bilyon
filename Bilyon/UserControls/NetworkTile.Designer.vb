<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetworkTile
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
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        NetworkMacLabel = New Label()
        IPLabel = New Label()
        StatusLabel = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(153, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 19)
        Label3.TabIndex = 21
        Label3.Text = "İp Adresi:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(153, 42)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 19)
        Label2.TabIndex = 20
        Label2.Text = "Durum:"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(153, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 19)
        Label1.TabIndex = 19
        Label1.Text = "Mac Adresi:"
        ' 
        ' NetworkMacLabel
        ' 
        NetworkMacLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        NetworkMacLabel.AutoSize = True
        NetworkMacLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        NetworkMacLabel.Location = New Point(166, 22)
        NetworkMacLabel.Name = "NetworkMacLabel"
        NetworkMacLabel.Size = New Size(114, 20)
        NetworkMacLabel.TabIndex = 18
        NetworkMacLabel.Text = "MAC ADDRESS"
        ' 
        ' IPLabel
        ' 
        IPLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        IPLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        IPLabel.Location = New Point(166, 99)
        IPLabel.Name = "IPLabel"
        IPLabel.Size = New Size(181, 48)
        IPLabel.TabIndex = 17
        IPLabel.Text = "127.0.0.1"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        StatusLabel.AutoSize = True
        StatusLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        StatusLabel.Location = New Point(166, 61)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(80, 19)
        StatusLabel.TabIndex = 16
        StatusLabel.Text = "Çevrimdışı"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.ethernet
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(144, 144)
        PictureBox1.TabIndex = 15
        PictureBox1.TabStop = False
        ' 
        ' NetworkTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(NetworkMacLabel)
        Controls.Add(IPLabel)
        Controls.Add(StatusLabel)
        Controls.Add(PictureBox1)
        Name = "NetworkTile"
        Size = New Size(350, 150)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NetworkMacLabel As Label
    Friend WithEvents IPLabel As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents PictureBox1 As PictureBox

End Class
