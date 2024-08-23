Imports Microsoft.VisualBasic.Devices
Imports System.Reflection.Emit

Public Class ScreenTile
    Public ScreenItem As Screen

    Public Sub SetValues(ByVal _screen As Screen)
        ScreenItem = _screen
        ScreenModelLabel.Text = ScreenItem.Model
        ResolutionLabel.Text = "Çözünürlük: " + ScreenItem.Resolution
        RefreshRateLabel.Text = "Yenileme Hızı: " + ScreenItem.RefreshRate
    End Sub
End Class
