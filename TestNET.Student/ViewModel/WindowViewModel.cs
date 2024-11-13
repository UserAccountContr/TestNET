using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class WindowViewModel : BaseViewModel
{
    public WindowViewModel(INavigationService navigationService)
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
