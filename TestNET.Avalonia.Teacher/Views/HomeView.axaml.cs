using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace TestNET.Avalonia.Teacher.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void Test_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Grid grid && grid.DataContext is TeacherTest ttest && DataContext is HomeViewModel hmv)
        {
            hmv.OpenTestViewCommand.Execute(ttest);
        }
        //throw new NotImplementedException();
    }
}