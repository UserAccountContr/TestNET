using TestNET.Avalonia.Teacher.Service;

namespace TestNET.Avalonia.Teacher.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    INavigationService navigation;

    public MainViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;

        Navigation.NavigateTo<HomeViewModel>();
    }
}
