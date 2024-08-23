Public Class RamTile
    Public RamItem As RAM

    Public Sub SetValues(ByVal _ram As RAM)
        RamItem = _ram
        RamModelLabel.Text = RamItem.Model
        CapacityLabel.Text = "Kapasite: " + RamItem.Capacity
    End Sub
End Class
