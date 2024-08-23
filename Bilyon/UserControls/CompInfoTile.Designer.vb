<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompInfoTile
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompInfoTile))
        StatusPictureBox = New PictureBox()
        CompNameLabel = New Label()
        IPLabel = New Label()
        StatusLabel = New Label()
        LastSeenLabel = New Label()
        InfoButton = New Button()
        UpdateTimer = New Timer(components)
        CType(StatusPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' StatusPictureBox
        ' 
        StatusPictureBox.Image = CType(resources.GetObject("StatusPictureBox.Image"), Image)
        StatusPictureBox.Location = New Point(13, 11)
        StatusPictureBox.Name = "StatusPictureBox"
        StatusPictureBox.Size = New Size(105, 90)
        StatusPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        StatusPictureBox.TabIndex = 0
        StatusPictureBox.TabStop = False
        ' 
        ' CompNameLabel
        ' 
        CompNameLabel.AutoSize = True
        CompNameLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        CompNameLabel.Location = New Point(124, 2)
        CompNameLabel.Name = "CompNameLabel"
        CompNameLabel.Size = New Size(136, 21)
        CompNameLabel.TabIndex = 1
        CompNameLabel.Text = "DESKTOP-HT4GS"
        ' 
        ' IPLabel
        ' 
        IPLabel.AutoSize = True
        IPLabel.Font = New Font("Segoe UI", 10F)
        IPLabel.Location = New Point(125, 24)
        IPLabel.Name = "IPLabel"
        IPLabel.Size = New Size(85, 19)
        IPLabel.TabIndex = 2
        IPLabel.Text = "IP: 127.0.0.1"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.AutoSize = True
        StatusLabel.Font = New Font("Segoe UI", 10F)
        StatusLabel.Location = New Point(125, 43)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(55, 19)
        StatusLabel.TabIndex = 3
        StatusLabel.Text = "Durum:"
        ' 
        ' LastSeenLabel
        ' 
        LastSeenLabel.AutoSize = True
        LastSeenLabel.Font = New Font("Segoe UI", 10F)
        LastSeenLabel.Location = New Point(126, 63)
        LastSeenLabel.Name = "LastSeenLabel"
        LastSeenLabel.Size = New Size(92, 19)
        LastSeenLabel.TabIndex = 4
        LastSeenLabel.Text = "Son Görülme:"
        ' 
        ' InfoButton
        ' 
        InfoButton.Location = New Point(126, 83)
        InfoButton.Name = "InfoButton"
        InfoButton.Size = New Size(173, 23)
        InfoButton.TabIndex = 5
        InfoButton.Text = "Bilgi"
        InfoButton.UseVisualStyleBackColor = True
        ' 
        ' UpdateTimer
        ' 
        UpdateTimer.Interval = 60000
        ' 
        ' CompInfoTile
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.LightCoral
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(InfoButton)
        Controls.Add(LastSeenLabel)
        Controls.Add(StatusLabel)
        Controls.Add(IPLabel)
        Controls.Add(CompNameLabel)
        Controls.Add(StatusPictureBox)
        Name = "CompInfoTile"
        Size = New Size(306, 112)
        CType(StatusPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents StatusPictureBox As PictureBox
    Friend WithEvents CompNameLabel As Label
    Friend WithEvents IPLabel As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents LastSeenLabel As Label
    Friend WithEvents InfoButton As Button
    Friend WithEvents UpdateTimer As Timer

End Class
