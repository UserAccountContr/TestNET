namespace TestNET.Teacher.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new TestViewModel();
        InitializeComponent();
    }
}