namespace TestNET.Student.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new WindowViewModel();
        InitializeComponent();
    }
}