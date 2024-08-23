Imports System
Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.BilYon.Migrations
    ''' <inheritdoc />
    Partial Public Class Init
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="CompDetail",
                columns:=Function(table) New With {
                    .GUID = table.Column(Of String)(type:="TEXT", maxLength:=36, nullable:=False),
                    .CPU_Model = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .CPU_Cores = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .CPU_Util = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .MotherboardModel = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .RAMDevice = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .RAMUtilization = table.Column(Of Single)(type:="REAL", nullable:=False),
                    .GPUModel = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Drives = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Screens = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .NetworkInterfaces = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Uptime = table.Column(Of TimeSpan)(type:="TEXT", nullable:=False),
                    .RTCTime = table.Column(Of Date)(type:="TEXT", nullable:=False),
                    .BatteryStatus = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .BatteryLevel = table.Column(Of Integer)(type:="INTEGER", nullable:=False),
                    .WindowsVersion = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .WindowsRegionLanguage = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .CurrentUserName = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .CurrentUserType = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .FocusedApplicationName = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .RunningPrograms = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .InstalledPrograms = table.Column(Of String)(type:="TEXT", nullable:=True)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_CompDetail", Function(x) x.GUID)
                End Sub)

            migrationBuilder.CreateTable(
                name:="Computers",
                columns:=Function(table) New With {
                    .GUID = table.Column(Of String)(type:="TEXT", maxLength:=36, nullable:=False),
                    .Host_Name = table.Column(Of String)(type:="TEXT", maxLength:=50, nullable:=False),
                    .Local_Ip = table.Column(Of String)(type:="TEXT", maxLength:=15, nullable:=False),
                    .Mac_Adress = table.Column(Of String)(type:="TEXT", maxLength:=17, nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Computers", Function(x) x.GUID)
                End Sub)

            migrationBuilder.CreateTable(
                name:="LastSeen",
                columns:=Function(table) New With {
                    .ID = table.Column(Of Integer)(type:="INTEGER", nullable:=False).
                        Annotation("Sqlite:Autoincrement", True),
                    .COMP_GUID = table.Column(Of String)(type:="TEXT", maxLength:=36, nullable:=False),
                    .LastSeenTime = table.Column(Of Date)(type:="TEXT", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_LastSeen", Function(x) x.ID)
                End Sub)

            migrationBuilder.CreateTable(
                name:="Settings",
                columns:=Function(table) New With {
                    .Setting = table.Column(Of String)(type:="TEXT", nullable:=False),
                    .Value = table.Column(Of String)(type:="TEXT", nullable:=True)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Settings", Function(x) x.Setting)
                End Sub)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="CompDetail")

            migrationBuilder.DropTable(
                name:="Computers")

            migrationBuilder.DropTable(
                name:="LastSeen")

            migrationBuilder.DropTable(
                name:="Settings")
        End Sub
    End Class
End Namespace
