<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComputerInfo
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
        InfoTabs = New TabControl()
        InfoTab = New TabPage()
        FocusedAppLabel = New Label()
        Label21 = New Label()
        UptimeLabel = New Label()
        RTCLabel = New Label()
        PictureBox1 = New PictureBox()
        UserTypeLabel = New Label()
        UserNameLabel = New Label()
        WindowsLocaleLabel = New Label()
        Label15 = New Label()
        WindowsVersionLabel = New Label()
        BatteryLevelLabel = New Label()
        Label12 = New Label()
        BatteryStatusLabel = New Label()
        GPUModelLabel = New Label()
        Label9 = New Label()
        Label8 = New Label()
        RamUtilLabel = New Label()
        TotalRamLabel = New Label()
        MotherboardLabel = New Label()
        CPUUtilLabel = New Label()
        CPUCoreLabel = New Label()
        CPUModelLabel = New Label()
        Label1 = New Label()
        ScreenTab = New TabPage()
        ScreenFlowLayout = New FlowLayoutPanel()
        Label2 = New Label()
        RamTab = New TabPage()
        RamFlowLayout = New FlowLayoutPanel()
        Label3 = New Label()
        DriveTab = New TabPage()
        DriveFlowLayout = New FlowLayoutPanel()
        Label4 = New Label()
        NetworkTab = New TabPage()
        NetworkFlowLayout = New FlowLayoutPanel()
        Label5 = New Label()
        RunningTab = New TabPage()
        Label23 = New Label()
        RunningAppsInfoGV = New DataGridView()
        AppTab = New TabPage()
        SendApp = New Button()
        InstalledAppsLabel = New Label()
        InstalledAppsGV = New DataGridView()
        CompNameLabel = New Label()
        IPLabel = New Label()
        MACLabel = New Label()
        StatusLabel = New Label()
        StatusUpdateTimer = New Timer(components)
        Label22 = New Label()
        DeleteComputerButton = New Button()
        InfoTabs.SuspendLayout()
        InfoTab.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        ScreenTab.SuspendLayout()
        RamTab.SuspendLayout()
        DriveTab.SuspendLayout()
        NetworkTab.SuspendLayout()
        RunningTab.SuspendLayout()
        CType(RunningAppsInfoGV, ComponentModel.ISupportInitialize).BeginInit()
        AppTab.SuspendLayout()
        CType(InstalledAppsGV, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' InfoTabs
        ' 
        InfoTabs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        InfoTabs.Controls.Add(InfoTab)
        InfoTabs.Controls.Add(ScreenTab)
        InfoTabs.Controls.Add(RamTab)
        InfoTabs.Controls.Add(DriveTab)
        InfoTabs.Controls.Add(NetworkTab)
        InfoTabs.Controls.Add(RunningTab)
        InfoTabs.Controls.Add(AppTab)
        InfoTabs.Font = New Font("Segoe UI", 10.5F)
        InfoTabs.Location = New Point(12, 38)
        InfoTabs.Name = "InfoTabs"
        InfoTabs.SelectedIndex = 0
        InfoTabs.Size = New Size(860, 531)
        InfoTabs.TabIndex = 0
        ' 
        ' InfoTab
        ' 
        InfoTab.Controls.Add(DeleteComputerButton)
        InfoTab.Controls.Add(FocusedAppLabel)
        InfoTab.Controls.Add(Label21)
        InfoTab.Controls.Add(UptimeLabel)
        InfoTab.Controls.Add(RTCLabel)
        InfoTab.Controls.Add(PictureBox1)
        InfoTab.Controls.Add(UserTypeLabel)
        InfoTab.Controls.Add(UserNameLabel)
        InfoTab.Controls.Add(WindowsLocaleLabel)
        InfoTab.Controls.Add(Label15)
        InfoTab.Controls.Add(WindowsVersionLabel)
        InfoTab.Controls.Add(BatteryLevelLabel)
        InfoTab.Controls.Add(Label12)
        InfoTab.Controls.Add(BatteryStatusLabel)
        InfoTab.Controls.Add(GPUModelLabel)
        InfoTab.Controls.Add(Label9)
        InfoTab.Controls.Add(Label8)
        InfoTab.Controls.Add(RamUtilLabel)
        InfoTab.Controls.Add(TotalRamLabel)
        InfoTab.Controls.Add(MotherboardLabel)
        InfoTab.Controls.Add(CPUUtilLabel)
        InfoTab.Controls.Add(CPUCoreLabel)
        InfoTab.Controls.Add(CPUModelLabel)
        InfoTab.Controls.Add(Label1)
        InfoTab.Location = New Point(4, 28)
        InfoTab.Name = "InfoTab"
        InfoTab.Padding = New Padding(3)
        InfoTab.Size = New Size(852, 499)
        InfoTab.TabIndex = 0
        InfoTab.Text = "Genel Bilgi"
        InfoTab.UseVisualStyleBackColor = True
        ' 
        ' FocusedAppLabel
        ' 
        FocusedAppLabel.AutoSize = True
        FocusedAppLabel.Font = New Font("Segoe UI", 12F)
        FocusedAppLabel.Location = New Point(259, 469)
        FocusedAppLabel.Name = "FocusedAppLabel"
        FocusedAppLabel.Size = New Size(197, 21)
        FocusedAppLabel.TabIndex = 30
        FocusedAppLabel.Text = "Bilyon - Visual Studio 2022"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label21.Location = New Point(6, 469)
        Label21.Name = "Label21"
        Label21.Size = New Size(247, 21)
        Label21.TabIndex = 27
        Label21.Text = "Son Odaklanan Uygulama Adı :"
        ' 
        ' UptimeLabel
        ' 
        UptimeLabel.AutoSize = True
        UptimeLabel.Font = New Font("Segoe UI", 12F)
        UptimeLabel.Location = New Point(287, 261)
        UptimeLabel.Name = "UptimeLabel"
        UptimeLabel.Size = New Size(140, 21)
        UptimeLabel.TabIndex = 26
        UptimeLabel.Text = "Açık Kalma Süresi :"
        ' 
        ' RTCLabel
        ' 
        RTCLabel.AutoSize = True
        RTCLabel.Font = New Font("Segoe UI", 12F)
        RTCLabel.Location = New Point(287, 240)
        RTCLabel.Name = "RTCLabel"
        RTCLabel.Size = New Size(102, 21)
        RTCLabel.TabIndex = 25
        RTCLabel.Text = "Bios Zamanı :"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.win11
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(6, 6)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(250, 250)
        PictureBox1.TabIndex = 24
        PictureBox1.TabStop = False
        ' 
        ' UserTypeLabel
        ' 
        UserTypeLabel.AutoSize = True
        UserTypeLabel.Font = New Font("Segoe UI", 12F)
        UserTypeLabel.Location = New Point(21, 367)
        UserTypeLabel.Name = "UserTypeLabel"
        UserTypeLabel.Size = New Size(104, 21)
        UserTypeLabel.TabIndex = 23
        UserTypeLabel.Text = "Kullanıcı Tipi :"
        ' 
        ' UserNameLabel
        ' 
        UserNameLabel.AutoSize = True
        UserNameLabel.Font = New Font("Segoe UI", 12F)
        UserNameLabel.Location = New Point(21, 346)
        UserNameLabel.Name = "UserNameLabel"
        UserNameLabel.Size = New Size(108, 21)
        UserNameLabel.TabIndex = 22
        UserNameLabel.Text = "Kullanıcı İsmi :"
        ' 
        ' WindowsLocaleLabel
        ' 
        WindowsLocaleLabel.AutoSize = True
        WindowsLocaleLabel.Font = New Font("Segoe UI", 12F)
        WindowsLocaleLabel.Location = New Point(21, 325)
        WindowsLocaleLabel.Name = "WindowsLocaleLabel"
        WindowsLocaleLabel.Size = New Size(208, 21)
        WindowsLocaleLabel.TabIndex = 21
        WindowsLocaleLabel.Text = "Windows Dil ve Bölge Ayarı :"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label15.Location = New Point(6, 279)
        Label15.Name = "Label15"
        Label15.Size = New Size(146, 25)
        Label15.TabIndex = 20
        Label15.Text = "Windows Bilgisi"
        ' 
        ' WindowsVersionLabel
        ' 
        WindowsVersionLabel.AutoSize = True
        WindowsVersionLabel.Font = New Font("Segoe UI", 12F)
        WindowsVersionLabel.Location = New Point(21, 304)
        WindowsVersionLabel.Name = "WindowsVersionLabel"
        WindowsVersionLabel.Size = New Size(142, 21)
        WindowsVersionLabel.TabIndex = 19
        WindowsVersionLabel.Text = "Windows Sürümü :"
        ' 
        ' BatteryLevelLabel
        ' 
        BatteryLevelLabel.AutoSize = True
        BatteryLevelLabel.Font = New Font("Segoe UI", 12F)
        BatteryLevelLabel.Location = New Point(15, 440)
        BatteryLevelLabel.Name = "BatteryLevelLabel"
        BatteryLevelLabel.Size = New Size(129, 21)
        BatteryLevelLabel.TabIndex = 18
        BatteryLevelLabel.Text = "Batarya Seviyesi :"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label12.Location = New Point(0, 393)
        Label12.Name = "Label12"
        Label12.Size = New Size(135, 25)
        Label12.TabIndex = 17
        Label12.Text = "Batarya Bilgisi"
        ' 
        ' BatteryStatusLabel
        ' 
        BatteryStatusLabel.AutoSize = True
        BatteryStatusLabel.Font = New Font("Segoe UI", 12F)
        BatteryStatusLabel.Location = New Point(15, 419)
        BatteryStatusLabel.Name = "BatteryStatusLabel"
        BatteryStatusLabel.Size = New Size(131, 21)
        BatteryStatusLabel.TabIndex = 16
        BatteryStatusLabel.Text = "Batarya Durumu :"
        ' 
        ' GPUModelLabel
        ' 
        GPUModelLabel.AutoSize = True
        GPUModelLabel.Font = New Font("Segoe UI", 12F)
        GPUModelLabel.Location = New Point(287, 219)
        GPUModelLabel.Name = "GPUModelLabel"
        GPUModelLabel.Size = New Size(144, 21)
        GPUModelLabel.TabIndex = 15
        GPUModelLabel.Text = "Ekran Kartı Modeli :"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label9.Location = New Point(272, 102)
        Label9.Name = "Label9"
        Label9.Size = New Size(106, 25)
        Label9.TabIndex = 14
        Label9.Text = "Ram Bilgisi"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label8.Location = New Point(272, 173)
        Label8.Name = "Label8"
        Label8.Size = New Size(145, 25)
        Label8.TabIndex = 13
        Label8.Text = "Donanım Bilgisi"
        ' 
        ' RamUtilLabel
        ' 
        RamUtilLabel.AutoSize = True
        RamUtilLabel.Font = New Font("Segoe UI", 12F)
        RamUtilLabel.Location = New Point(286, 148)
        RamUtilLabel.Name = "RamUtilLabel"
        RamUtilLabel.Size = New Size(121, 21)
        RamUtilLabel.TabIndex = 12
        RamUtilLabel.Text = "Kullanılan Ram :"
        ' 
        ' TotalRamLabel
        ' 
        TotalRamLabel.AutoSize = True
        TotalRamLabel.Font = New Font("Segoe UI", 12F)
        TotalRamLabel.Location = New Point(286, 127)
        TotalRamLabel.Name = "TotalRamLabel"
        TotalRamLabel.Size = New Size(103, 21)
        TotalRamLabel.TabIndex = 11
        TotalRamLabel.Text = "Toplam Ram :"
        ' 
        ' MotherboardLabel
        ' 
        MotherboardLabel.AutoSize = True
        MotherboardLabel.Font = New Font("Segoe UI", 12F)
        MotherboardLabel.Location = New Point(287, 198)
        MotherboardLabel.Name = "MotherboardLabel"
        MotherboardLabel.Size = New Size(123, 21)
        MotherboardLabel.TabIndex = 10
        MotherboardLabel.Text = "Anakart Modeli :"
        ' 
        ' CPUUtilLabel
        ' 
        CPUUtilLabel.AutoSize = True
        CPUUtilLabel.Font = New Font("Segoe UI", 12F)
        CPUUtilLabel.Location = New Point(287, 77)
        CPUUtilLabel.Name = "CPUUtilLabel"
        CPUUtilLabel.Size = New Size(134, 21)
        CPUUtilLabel.TabIndex = 9
        CPUUtilLabel.Text = "İşlemci Kullanımı :"
        ' 
        ' CPUCoreLabel
        ' 
        CPUCoreLabel.AutoSize = True
        CPUCoreLabel.Font = New Font("Segoe UI", 12F)
        CPUCoreLabel.Location = New Point(287, 56)
        CPUCoreLabel.Name = "CPUCoreLabel"
        CPUCoreLabel.Size = New Size(122, 21)
        CPUCoreLabel.TabIndex = 8
        CPUCoreLabel.Text = "Çekirdek Sayısı :"
        ' 
        ' CPUModelLabel
        ' 
        CPUModelLabel.AutoSize = True
        CPUModelLabel.Font = New Font("Segoe UI", 12F)
        CPUModelLabel.Location = New Point(287, 35)
        CPUModelLabel.Name = "CPUModelLabel"
        CPUModelLabel.Size = New Size(65, 21)
        CPUModelLabel.TabIndex = 7
        CPUModelLabel.Text = "İşlemci :"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label1.Location = New Point(272, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 25)
        Label1.TabIndex = 6
        Label1.Text = "İşlemci Bilgisi"
        ' 
        ' ScreenTab
        ' 
        ScreenTab.Controls.Add(ScreenFlowLayout)
        ScreenTab.Controls.Add(Label2)
        ScreenTab.Location = New Point(4, 28)
        ScreenTab.Name = "ScreenTab"
        ScreenTab.Size = New Size(852, 499)
        ScreenTab.TabIndex = 2
        ScreenTab.Text = "Ekran Bilgileri"
        ScreenTab.UseVisualStyleBackColor = True
        ' 
        ' ScreenFlowLayout
        ' 
        ScreenFlowLayout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ScreenFlowLayout.AutoScroll = True
        ScreenFlowLayout.BorderStyle = BorderStyle.FixedSingle
        ScreenFlowLayout.Location = New Point(3, 31)
        ScreenFlowLayout.Name = "ScreenFlowLayout"
        ScreenFlowLayout.Size = New Size(846, 465)
        ScreenFlowLayout.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label2.Location = New Point(3, 3)
        Label2.Name = "Label2"
        Label2.Size = New Size(130, 25)
        Label2.TabIndex = 7
        Label2.Text = "Bağlı Ekranlar"
        ' 
        ' RamTab
        ' 
        RamTab.Controls.Add(RamFlowLayout)
        RamTab.Controls.Add(Label3)
        RamTab.Location = New Point(4, 28)
        RamTab.Name = "RamTab"
        RamTab.Padding = New Padding(3)
        RamTab.Size = New Size(852, 499)
        RamTab.TabIndex = 1
        RamTab.Text = "Ram Bilgisi"
        RamTab.UseVisualStyleBackColor = True
        ' 
        ' RamFlowLayout
        ' 
        RamFlowLayout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RamFlowLayout.AutoScroll = True
        RamFlowLayout.BorderStyle = BorderStyle.FixedSingle
        RamFlowLayout.Location = New Point(3, 31)
        RamFlowLayout.Name = "RamFlowLayout"
        RamFlowLayout.Size = New Size(846, 465)
        RamFlowLayout.TabIndex = 10
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label3.Location = New Point(3, 3)
        Label3.Name = "Label3"
        Label3.Size = New Size(197, 25)
        Label3.TabIndex = 9
        Label3.Text = "Sisteme Takılı Ram'ler"
        ' 
        ' DriveTab
        ' 
        DriveTab.Controls.Add(DriveFlowLayout)
        DriveTab.Controls.Add(Label4)
        DriveTab.Location = New Point(4, 28)
        DriveTab.Name = "DriveTab"
        DriveTab.Size = New Size(852, 499)
        DriveTab.TabIndex = 3
        DriveTab.Text = "Depolama Cihazları"
        DriveTab.UseVisualStyleBackColor = True
        ' 
        ' DriveFlowLayout
        ' 
        DriveFlowLayout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DriveFlowLayout.AutoScroll = True
        DriveFlowLayout.BorderStyle = BorderStyle.FixedSingle
        DriveFlowLayout.Location = New Point(3, 31)
        DriveFlowLayout.Name = "DriveFlowLayout"
        DriveFlowLayout.Size = New Size(846, 465)
        DriveFlowLayout.TabIndex = 12
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label4.Location = New Point(3, 3)
        Label4.Name = "Label4"
        Label4.Size = New Size(296, 25)
        Label4.TabIndex = 11
        Label4.Text = "Sisteme Takılı Depolama Cihazları"
        ' 
        ' NetworkTab
        ' 
        NetworkTab.Controls.Add(NetworkFlowLayout)
        NetworkTab.Controls.Add(Label5)
        NetworkTab.Location = New Point(4, 28)
        NetworkTab.Name = "NetworkTab"
        NetworkTab.Size = New Size(852, 499)
        NetworkTab.TabIndex = 4
        NetworkTab.Text = "Ağ Bağdaştırıcıları"
        NetworkTab.UseVisualStyleBackColor = True
        ' 
        ' NetworkFlowLayout
        ' 
        NetworkFlowLayout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        NetworkFlowLayout.AutoScroll = True
        NetworkFlowLayout.BorderStyle = BorderStyle.FixedSingle
        NetworkFlowLayout.Location = New Point(3, 31)
        NetworkFlowLayout.Name = "NetworkFlowLayout"
        NetworkFlowLayout.Size = New Size(846, 465)
        NetworkFlowLayout.TabIndex = 14
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label5.Location = New Point(3, 3)
        Label5.Name = "Label5"
        Label5.Size = New Size(287, 25)
        Label5.TabIndex = 13
        Label5.Text = "Sisteme Bağlı Ağ Bağdaştırıcıları"
        ' 
        ' RunningTab
        ' 
        RunningTab.Controls.Add(Label23)
        RunningTab.Controls.Add(RunningAppsInfoGV)
        RunningTab.Location = New Point(4, 28)
        RunningTab.Name = "RunningTab"
        RunningTab.Size = New Size(852, 499)
        RunningTab.TabIndex = 5
        RunningTab.Text = "Çalışan Uygulamalar"
        RunningTab.UseVisualStyleBackColor = True
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label23.Location = New Point(3, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(195, 25)
        Label23.TabIndex = 31
        Label23.Text = "Çalışan Uygulamalar :"
        ' 
        ' RunningAppsInfoGV
        ' 
        RunningAppsInfoGV.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RunningAppsInfoGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        RunningAppsInfoGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        RunningAppsInfoGV.Location = New Point(3, 28)
        RunningAppsInfoGV.Name = "RunningAppsInfoGV"
        RunningAppsInfoGV.Size = New Size(846, 468)
        RunningAppsInfoGV.TabIndex = 30
        ' 
        ' AppTab
        ' 
        AppTab.Controls.Add(SendApp)
        AppTab.Controls.Add(InstalledAppsLabel)
        AppTab.Controls.Add(InstalledAppsGV)
        AppTab.Location = New Point(4, 28)
        AppTab.Name = "AppTab"
        AppTab.Size = New Size(852, 499)
        AppTab.TabIndex = 6
        AppTab.Text = "Yüklü Uygulamalar"
        AppTab.UseVisualStyleBackColor = True
        ' 
        ' SendApp
        ' 
        SendApp.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SendApp.Font = New Font("Segoe UI", 11F)
        SendApp.Location = New Point(730, 3)
        SendApp.Name = "SendApp"
        SendApp.Size = New Size(119, 52)
        SendApp.TabIndex = 34
        SendApp.Text = "Uygulama Gönder"
        SendApp.UseVisualStyleBackColor = True
        ' 
        ' InstalledAppsLabel
        ' 
        InstalledAppsLabel.AutoSize = True
        InstalledAppsLabel.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        InstalledAppsLabel.Location = New Point(3, 33)
        InstalledAppsLabel.Name = "InstalledAppsLabel"
        InstalledAppsLabel.Size = New Size(182, 25)
        InstalledAppsLabel.TabIndex = 33
        InstalledAppsLabel.Text = "Yüklü Uygulamalar :"
        ' 
        ' InstalledAppsGV
        ' 
        InstalledAppsGV.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        InstalledAppsGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        InstalledAppsGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        InstalledAppsGV.Location = New Point(3, 61)
        InstalledAppsGV.Name = "InstalledAppsGV"
        InstalledAppsGV.Size = New Size(846, 436)
        InstalledAppsGV.TabIndex = 32
        ' 
        ' CompNameLabel
        ' 
        CompNameLabel.AutoSize = True
        CompNameLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        CompNameLabel.Location = New Point(4, 4)
        CompNameLabel.Name = "CompNameLabel"
        CompNameLabel.Size = New Size(190, 30)
        CompNameLabel.TabIndex = 2
        CompNameLabel.Text = "DESKTOP-HT4GS"
        ' 
        ' IPLabel
        ' 
        IPLabel.Anchor = AnchorStyles.Top
        IPLabel.AutoSize = True
        IPLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        IPLabel.Location = New Point(468, 15)
        IPLabel.Name = "IPLabel"
        IPLabel.Size = New Size(97, 20)
        IPLabel.TabIndex = 3
        IPLabel.Text = "IP: 127.0.0.1"
        ' 
        ' MACLabel
        ' 
        MACLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        MACLabel.AutoSize = True
        MACLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        MACLabel.Location = New Point(690, 15)
        MACLabel.Name = "MACLabel"
        MACLabel.Size = New Size(182, 20)
        MACLabel.TabIndex = 4
        MACLabel.Text = "MAC: DB:14:E2:CB:53:32"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.Anchor = AnchorStyles.Top
        StatusLabel.AutoSize = True
        StatusLabel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        StatusLabel.ForeColor = Color.Red
        StatusLabel.Location = New Point(360, 15)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(82, 20)
        StatusLabel.TabIndex = 5
        StatusLabel.Text = "Çevrimdışı"
        ' 
        ' StatusUpdateTimer
        ' 
        StatusUpdateTimer.Interval = 5000
        ' 
        ' Label22
        ' 
        Label22.Anchor = AnchorStyles.Top
        Label22.AutoSize = True
        Label22.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label22.Location = New Point(302, 15)
        Label22.Name = "Label22"
        Label22.Size = New Size(62, 20)
        Label22.TabIndex = 7
        Label22.Text = "Durum:"
        ' 
        ' DeleteComputerButton
        ' 
        DeleteComputerButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        DeleteComputerButton.BackColor = Color.Transparent
        DeleteComputerButton.Font = New Font("Segoe UI", 11F)
        DeleteComputerButton.Location = New Point(727, 441)
        DeleteComputerButton.Name = "DeleteComputerButton"
        DeleteComputerButton.Size = New Size(119, 52)
        DeleteComputerButton.TabIndex = 35
        DeleteComputerButton.Text = "Bilgisayarı Sil"
        DeleteComputerButton.UseVisualStyleBackColor = False
        ' 
        ' ComputerInfo
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(244), CByte(241), CByte(249))
        ClientSize = New Size(884, 581)
        Controls.Add(Label22)
        Controls.Add(StatusLabel)
        Controls.Add(MACLabel)
        Controls.Add(IPLabel)
        Controls.Add(CompNameLabel)
        Controls.Add(InfoTabs)
        MinimumSize = New Size(900, 620)
        Name = "ComputerInfo"
        StartPosition = FormStartPosition.CenterParent
        Text = "Bilgisayar Detayları"
        InfoTabs.ResumeLayout(False)
        InfoTab.ResumeLayout(False)
        InfoTab.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ScreenTab.ResumeLayout(False)
        ScreenTab.PerformLayout()
        RamTab.ResumeLayout(False)
        RamTab.PerformLayout()
        DriveTab.ResumeLayout(False)
        DriveTab.PerformLayout()
        NetworkTab.ResumeLayout(False)
        NetworkTab.PerformLayout()
        RunningTab.ResumeLayout(False)
        RunningTab.PerformLayout()
        CType(RunningAppsInfoGV, ComponentModel.ISupportInitialize).EndInit()
        AppTab.ResumeLayout(False)
        AppTab.PerformLayout()
        CType(InstalledAppsGV, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents InfoTabs As TabControl
    Friend WithEvents InfoTab As TabPage
    Friend WithEvents RamTab As TabPage
    Friend WithEvents CompNameLabel As Label
    Friend WithEvents IPLabel As Label
    Friend WithEvents MACLabel As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents StatusUpdateTimer As Timer
    Friend WithEvents ScreenTab As TabPage
    Friend WithEvents DriveTab As TabPage
    Friend WithEvents NetworkTab As TabPage
    Friend WithEvents RunningTab As TabPage
    Friend WithEvents AppTab As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents MotherboardLabel As Label
    Friend WithEvents CPUUtilLabel As Label
    Friend WithEvents CPUCoreLabel As Label
    Friend WithEvents CPUModelLabel As Label
    Friend WithEvents TotalRamLabel As Label
    Friend WithEvents GPUModelLabel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents RamUtilLabel As Label
    Friend WithEvents BatteryLevelLabel As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents BatteryStatusLabel As Label
    Friend WithEvents WindowsLocaleLabel As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents WindowsVersionLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents UserTypeLabel As Label
    Friend WithEvents UserNameLabel As Label
    Friend WithEvents UptimeLabel As Label
    Friend WithEvents RTCLabel As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents FocusedAppLabel As Label
    Friend WithEvents ScreenFlowLayout As FlowLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents RunningAppsInfoGV As DataGridView
    Friend WithEvents InstalledAppsLabel As Label
    Friend WithEvents InstalledAppsGV As DataGridView
    Friend WithEvents SendApp As Button
    Friend WithEvents RamFlowLayout As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents DriveFlowLayout As FlowLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents NetworkFlowLayout As FlowLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents DeleteComputerButton As Button
End Class
