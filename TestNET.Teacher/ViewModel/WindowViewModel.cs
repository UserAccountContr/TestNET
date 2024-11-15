using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

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
    void OpenTestView(object test) => Navigation.NavigateTo<TestViewModel, Test>(test as Test);

    [RelayCommand]
    void OpenEditTestView(object test) => Navigation.NavigateTo<EditTestViewModel, Test>(test as Test);

    [RelayCommand]
    void GoToHomeView() => Navigation.NavigateTo<HomeViewModel>();
}
