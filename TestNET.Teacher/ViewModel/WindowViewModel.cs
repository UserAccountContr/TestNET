using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class WindowViewModel : BaseViewModel
{
    public WindowViewModel(INavigationService navigationService)
    {
        //this.homeViewModel = homeViewModel;
        //CurrentPageViewModel = this.homeViewModel;

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


    //HomeViewModel homeViewModel;

    //[ObservableProperty]
    //ObservableObject currentPageViewModel;

    //[RelayCommand]
    //void OpenTestView(object test) => CurrentPageViewModel = new TestViewModel(test as Test);

    //[RelayCommand]
    //void OpenEditTestView(object test) => CurrentPageViewModel = new EditTestViewModel(test as Test);

    //[RelayCommand]
    //void GoToHomeView() => CurrentPageViewModel = homeViewModel;
}
