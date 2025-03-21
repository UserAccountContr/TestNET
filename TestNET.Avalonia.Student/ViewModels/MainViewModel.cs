using TestNET.Avalonia.Student.Service;

namespace TestNET.Avalonia.Student.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
        GoToHomeView();
    }

    [ObservableProperty]
    INavigationService navigation;

    [RelayCommand]
    void GoToHomeView() => Navigation.NavigateTo<HomeViewModel>();

    [RelayCommand]
    void StartTest(Test test) => Navigation.NavigateTo<TestSolvingViewModel, Test>(test);
}
