Imports System.Windows.Media.Animation
Imports System.Threading
Imports System.Windows.Controls.Primitives

Class MainWindow
    Dim CA As New CATIA_Lib.Cl_CATIA.UDF.ClashAnalysis
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Dim NewList As New List(Of clash)
        'NewList.Add(New clash() With {.Product1 = "ghjg"})
        'dg_Clashes.ItemsSource = NewList
    End Sub
    Private Sub TextBlock_MouseDown(sender As Object, e As MouseButtonEventArgs)
        CA.ActiveProductClash()
        sp_Main.Visibility = Visibility.Hidden

        Dim da As New DoubleAnimation
        'da.SetValue(win_BOMExport, HeightProperty) = 275
        da.From = win_MainWindow.Width
        da.To = win_MainWindow.Width + 1000
        da.AccelerationRatio = 0.8
        da.Duration = TimeSpan.FromSeconds(1)
        win_MainWindow.BeginAnimation(WidthProperty, da)

        lv_Clashes.Visibility = Visibility.Visible
        'CA.ActiveProductClash()

        Dim ClashesList = (From clash In CA.ListOfClashes
                           Select clash).ToList
        tblk_ProductDocument.Text = ClashesList(0).ProductDocument


        Dim lcv As New ListCollectionView(ClashesList)

        lcv.GroupDescriptions.Add(New PropertyGroupDescription("Type"))
        lcv.GroupDescriptions.Add(New PropertyGroupDescription("Priority"))

        'For Each item In lcv.ItemProperties
        '    MsgBox(item.Name)
        'Next
        lv_Clashes.DataContext = lcv

        'lv_Clashes.ItemsSource = ClashesList

        win_MainWindow.Left = win_MainWindow.Left - 500
        win_MainWindow.Top = win_MainWindow.Top - 250
        win_MainWindow.Height = win_MainWindow.Height + 500
        sp_StatusBar.Visibility = Visibility.Visible

        'Thread.Sleep(1000)

        ''da As New DoubleAnimation
        ''da.SetValue(win_BOMExport, HeightProperty) = 275
        'da.From = win_MainWindow.Height
        'da.To = win_MainWindow.Height + 500
        'da.AccelerationRatio = 0.8
        'da.Duration = TimeSpan.FromSeconds(1)
        'win_MainWindow.BeginAnimation(HeightProperty, da)
        'dg_Clashes.ItemsSource = ClashesList
    End Sub

    Private Sub win_MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles win_MainWindow.Loaded
        win_MainWindow.Width = 300
        win_MainWindow.Height = 300

        sp_Main.Visibility = Visibility.Visible
        lv_Clashes.Visibility = Visibility.Collapsed

        'Dim ClashesList = (From clash In CA.ListOfClashes
        '                   Select clash).ToList
        'DataContext = Me

        'lv_Clashes.ItemsSource = ClashesList



    End Sub


    Public Class clash
        Public Product1 As String, Product2 As String, ProductDocument As String, Type As String, Value As String, Status As String, Comment As String, Level As Integer

    End Class

    Private Sub tgl_Done_Click(sender As Object, e As RoutedEventArgs)
        Dim tgl As ToggleButton = CType(sender, ToggleButton)
        tgl.Background = New SolidColorBrush(Colors.Transparent)

        If tgl.IsChecked = True Then
            tgl.Foreground = New SolidColorBrush(Colors.DarkGreen)
            tgl.Background = New SolidColorBrush(Colors.Transparent)
            tgl.FontWeight = FontWeights.Bold
        Else
            tgl.Foreground = New SolidColorBrush(Colors.Gray)
            tgl.Background = New SolidColorBrush(Colors.Transparent)
            tgl.FontWeight = FontWeights.Light
        End If


    End Sub


End Class
