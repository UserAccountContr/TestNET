namespace TestNET.Teacher.View;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem mi)
        {
            if (mi.Icon is RadioButton rb)
            {
                rb.IsChecked = true;
            }
        }
    }
}