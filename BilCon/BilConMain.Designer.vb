<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BilConMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BilConMain))
        SettingsButton = New Button()
        TrayIcon = New NotifyIcon(components)
        ServerStatusStaticText = New Label()
        ServerIPStaticText = New Label()
        ServerIPText = New Label()
        ServerStatusText = New Label()
        SendInterval = New Timer(components)
        SuspendLayout()
        ' 
        ' SettingsButton
        ' 
        SettingsButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsButton.BackColor = Color.Transparent
        SettingsButton.BackgroundImageLayout = ImageLayout.Zoom
        SettingsButton.FlatAppearance.BorderSize = 0
        SettingsButton.FlatStyle = FlatStyle.Flat
        SettingsButton.Image = My.Resources.Resources.settings
        SettingsButton.Location = New Point(358, 12)
        SettingsButton.Name = "SettingsButton"
        SettingsButton.Size = New Size(40, 40)
        SettingsButton.TabIndex = 2
        SettingsButton.UseVisualStyleBackColor = False
        ' 
        ' TrayIcon
        ' 
        TrayIcon.BalloonTipIcon = ToolTipIcon.Info
        TrayIcon.BalloonTipText = "BilCon arkaplanda çalısıyor."
        TrayIcon.BalloonTipTitle = "Bilgisayar Arabirim Bağlantı Uygulaması"
        TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), Icon)
        TrayIcon.Text = "Bilgisayar Arabirim Bağlantı Uygulaması"
        ' 
        ' ServerStatusStaticText
        ' 
        ServerStatusStaticText.AutoSize = True
        ServerStatusStaticText.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        ServerStatusStaticText.Location = New Point(11, 9)
        ServerStatusStaticText.Margin = New Padding(2, 0, 2, 0)
        ServerStatusStaticText.Name = "ServerStatusStaticText"
        ServerStatusStaticText.Size = New Size(130, 21)
        ServerStatusStaticText.TabIndex = 3
        ServerStatusStaticText.Text = "Server Durumu:"
        ' 
        ' ServerIPStaticText
        ' 
        ServerIPStaticText.AutoSize = True
        ServerIPStaticText.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        ServerIPStaticText.Location = New Point(11, 39)
        ServerIPStaticText.Margin = New Padding(2, 0, 2, 0)
        ServerIPStaticText.Name = "ServerIPStaticText"
        ServerIPStaticText.Size = New Size(98, 21)
        ServerIPStaticText.TabIndex = 4
        ServerIPStaticText.Text = "Server IP'si:"
        ' 
        ' ServerIPText
        ' 
        ServerIPText.AutoSize = True
        ServerIPText.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ServerIPText.Location = New Point(114, 42)
        ServerIPText.Name = "ServerIPText"
        ServerIPText.Size = New Size(13, 17)
        ServerIPText.TabIndex = 5
        ServerIPText.Text = "-"
        ' 
        ' ServerStatusText
        ' 
        ServerStatusText.AutoSize = True
        ServerStatusText.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ServerStatusText.ForeColor = Color.Red
        ServerStatusText.Location = New Point(146, 12)
        ServerStatusText.Name = "ServerStatusText"
        ServerStatusText.Size = New Size(73, 17)
        ServerStatusText.TabIndex = 6
        ServerStatusText.Text = "Çevrimdışı"
        ' 
        ' SendInterval
        ' 
        SendInterval.Interval = 5000
        ' 
        ' BilConMain
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(410, 69)
        Controls.Add(ServerStatusText)
        Controls.Add(ServerIPText)
        Controls.Add(ServerIPStaticText)
        Controls.Add(ServerStatusStaticText)
        Controls.Add(SettingsButton)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "BilConMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BilCon - Bilgisayar Arabirim Bağlantı Uygulaması"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents SettingsButton As Button
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents ServerStatusStaticText As Label
    Friend WithEvents ServerIPStaticText As Label
    Friend WithEvents ServerIPText As Label
    Friend WithEvents ServerStatusText As Label
    Friend WithEvents SendInterval As Timer

End Class
