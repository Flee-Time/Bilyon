<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCompScreen
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        ConnectButton = New Button()
        IPLabel = New Label()
        LoadingPicture = New PictureBox()
        CheckerTimer = New Timer(components)
        CType(LoadingPicture, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 19)
        Label1.TabIndex = 0
        Label1.Text = "Server IP'si :"
        ' 
        ' ConnectButton
        ' 
        ConnectButton.Location = New Point(62, 76)
        ConnectButton.Name = "ConnectButton"
        ConnectButton.Size = New Size(113, 23)
        ConnectButton.TabIndex = 2
        ConnectButton.Text = "Eşleştirmeyi Başlat"
        ConnectButton.UseVisualStyleBackColor = True
        ' 
        ' IPLabel
        ' 
        IPLabel.AutoSize = True
        IPLabel.Font = New Font("Segoe UI", 10F)
        IPLabel.Location = New Point(21, 38)
        IPLabel.Name = "IPLabel"
        IPLabel.Size = New Size(66, 19)
        IPLabel.TabIndex = 3
        IPLabel.Text = "127.0.0.1"
        ' 
        ' LoadingPicture
        ' 
        LoadingPicture.Image = My.Resources.Resources.loading
        LoadingPicture.Location = New Point(172, 12)
        LoadingPicture.Name = "LoadingPicture"
        LoadingPicture.Size = New Size(50, 50)
        LoadingPicture.SizeMode = PictureBoxSizeMode.StretchImage
        LoadingPicture.TabIndex = 4
        LoadingPicture.TabStop = False
        LoadingPicture.Visible = False
        ' 
        ' CheckerTimer
        ' 
        CheckerTimer.Interval = 500
        ' 
        ' AddCompScreen
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(234, 111)
        Controls.Add(LoadingPicture)
        Controls.Add(IPLabel)
        Controls.Add(ConnectButton)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "AddCompScreen"
        StartPosition = FormStartPosition.CenterParent
        Text = "Ekle"
        CType(LoadingPicture, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ConnectButton As Button
    Friend WithEvents IPLabel As Label
    Friend WithEvents LoadingPicture As PictureBox
    Friend WithEvents CheckerTimer As Timer
End Class
