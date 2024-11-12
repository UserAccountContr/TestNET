namespace TestNET.Student.View;

public partial class MainWindow : Window
{
    public MainWindow(WindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}