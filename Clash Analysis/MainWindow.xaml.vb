Imports System.Windows.Media.Animation

Class MainWindow
    Private Sub TextBlock_MouseDown(sender As Object, e As MouseButtonEventArgs)
        tblk_NewClash.Visibility = Visibility.Hidden

        Dim da As New DoubleAnimation
        'da.SetValue(win_BOMExport, HeightProperty) = 275
        da.From = win_MainWindow.Width
        da.To = win_MainWindow.Width + 500
        da.AccelerationRatio = 0.8
        da.Duration = TimeSpan.FromSeconds(1)
        win_MainWindow.BeginAnimation(WidthProperty, da)

        lv_Clashes.Visibility = Visibility.Visible
    End Sub

    Private Sub win_MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles win_MainWindow.Loaded
        tblk_NewClash.Visibility = Visibility.Visible
        lv_Clashes.Visibility = Visibility.Hidden
    End Sub
End Class
