<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PairingScreen
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
        LoadingPicture = New PictureBox()
        ConnectButton = New Button()
        Label1 = New Label()
        IPTextBox = New TextBox()
        CType(LoadingPicture, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LoadingPicture
        ' 
        LoadingPicture.Image = My.Resources.Resources.loading
        LoadingPicture.Location = New Point(172, 12)
        LoadingPicture.Name = "LoadingPicture"
        LoadingPicture.Size = New Size(50, 50)
        LoadingPicture.SizeMode = PictureBoxSizeMode.StretchImage
        LoadingPicture.TabIndex = 8
        LoadingPicture.TabStop = False
        LoadingPicture.Visible = False
        ' 
        ' ConnectButton
        ' 
        ConnectButton.Location = New Point(62, 76)
        ConnectButton.Name = "ConnectButton"
        ConnectButton.Size = New Size(113, 23)
        ConnectButton.TabIndex = 6
        ConnectButton.Text = "Eşleştirmeyi Başlat"
        ConnectButton.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 19)
        Label1.TabIndex = 5
        Label1.Text = "Server IP'si :"
        ' 
        ' IPTextBox
        ' 
        IPTextBox.Location = New Point(12, 39)
        IPTextBox.Name = "IPTextBox"
        IPTextBox.Size = New Size(124, 23)
        IPTextBox.TabIndex = 9
        ' 
        ' PairingScreen
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(234, 111)
        Controls.Add(IPTextBox)
        Controls.Add(LoadingPicture)
        Controls.Add(ConnectButton)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "PairingScreen"
        Text = "Eşleşme"
        CType(LoadingPicture, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LoadingPicture As PictureBox
    Friend WithEvents ConnectButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents IPTextBox As TextBox
End Class
