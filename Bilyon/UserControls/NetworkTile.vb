Public Class NetworkTile
    Public NetworkItem As NInterface

    Public Sub SetValues(ByVal _network As NInterface)
        NetworkItem = _network
        NetworkMacLabel.Text = NetworkItem.MacAddress
        StatusLabel.Text = NetworkItem.Status
        IPLabel.Text = NetworkItem.IPAddress
    End Sub
End Class
