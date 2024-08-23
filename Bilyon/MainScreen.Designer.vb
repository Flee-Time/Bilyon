<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        ComputerFlowPanel = New FlowLayoutPanel()
        SettingsButton = New Button()
        CompNameLabel = New Label()
        TrayIcon = New NotifyIcon(components)
        RefreshButton = New Button()
        SuspendLayout()
        ' 
        ' ComputerFlowPanel
        ' 
        ComputerFlowPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ComputerFlowPanel.AutoScroll = True
        ComputerFlowPanel.BorderStyle = BorderStyle.FixedSingle
        ComputerFlowPanel.Location = New Point(12, 51)
        ComputerFlowPanel.Name = "ComputerFlowPanel"
        ComputerFlowPanel.Size = New Size(958, 403)
        ComputerFlowPanel.TabIndex = 0
        ' 
        ' SettingsButton
        ' 
        SettingsButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsButton.BackColor = Color.Transparent
        SettingsButton.BackgroundImage = My.Resources.Resources.settings
        SettingsButton.BackgroundImageLayout = ImageLayout.Zoom
        SettingsButton.FlatAppearance.BorderSize = 0
        SettingsButton.FlatStyle = FlatStyle.Flat
        SettingsButton.Location = New Point(938, 5)
        SettingsButton.Name = "SettingsButton"
        SettingsButton.Size = New Size(40, 40)
        SettingsButton.TabIndex = 1
        SettingsButton.UseVisualStyleBackColor = False
        ' 
        ' CompNameLabel
        ' 
        CompNameLabel.AutoSize = True
        CompNameLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        CompNameLabel.Location = New Point(12, 22)
        CompNameLabel.Margin = New Padding(2, 0, 2, 0)
        CompNameLabel.Name = "CompNameLabel"
        CompNameLabel.Size = New Size(110, 21)
        CompNameLabel.TabIndex = 2
        CompNameLabel.Text = "Bilgisayarlar:"
        ' 
        ' TrayIcon
        ' 
        TrayIcon.BalloonTipIcon = ToolTipIcon.Info
        TrayIcon.BalloonTipText = "BilYon arkaplanda çalısıyor."
        TrayIcon.BalloonTipTitle = "Bilgisayar Yönetim Konsolu"
        TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), Icon)
        TrayIcon.Text = "Bilgisayar Yönetim Konsolu"
        ' 
        ' RefreshButton
        ' 
        RefreshButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        RefreshButton.BackColor = Color.Transparent
        RefreshButton.BackgroundImage = My.Resources.Resources.refresh
        RefreshButton.BackgroundImageLayout = ImageLayout.Zoom
        RefreshButton.FlatAppearance.BorderSize = 0
        RefreshButton.FlatStyle = FlatStyle.Flat
        RefreshButton.Location = New Point(897, 8)
        RefreshButton.Name = "RefreshButton"
        RefreshButton.Size = New Size(35, 35)
        RefreshButton.TabIndex = 3
        RefreshButton.UseVisualStyleBackColor = False
        ' 
        ' MainScreen
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(984, 461)
        Controls.Add(RefreshButton)
        Controls.Add(CompNameLabel)
        Controls.Add(SettingsButton)
        Controls.Add(ComputerFlowPanel)
        MinimumSize = New Size(400, 400)
        Name = "MainScreen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Bilgisayar Yönetim Konsolu"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComputerFlowPanel As FlowLayoutPanel
    Friend WithEvents SettingsButton As Button
    Friend WithEvents CompNameLabel As Label
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents RefreshButton As Button

End Class
