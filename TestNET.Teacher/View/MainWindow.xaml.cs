namespace TestNET.Teacher.View;

public partial class MainWindow : Window
{
    public MainWindow(WindowViewModel vm)
    {
        DataContext = vm;
        Closing += vm.OnWindowClosing;
        InitializeComponent();
    }
}