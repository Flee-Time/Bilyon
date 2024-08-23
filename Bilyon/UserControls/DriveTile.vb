Public Class DriveTile
    Public DriveItem As DriveInfo

    Public Sub SetValues(ByVal _drive As DriveInfo)
        DriveItem = _drive
        DriveLetterLabel.Text = DriveItem.DriveLetter
        TotalSpaceLabel.Text = Str(Math.Round(DriveItem.TotalSpace / (1024 ^ 3), 1)) + "GB"
        FreeSpaceLabel.Text = Str(Math.Round(DriveItem.FreeSpace / (1024 ^ 3), 1)) + "GB"
    End Sub
End Class
