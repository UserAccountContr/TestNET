namespace TestNET.Teacher.ViewModel;

public partial class WindowViewModel: BaseViewModel
{
    public WindowViewModel()
    {
        homeViewModel = new HomeViewModel();
        currentPageViewModel = homeViewModel;
    }

    HomeViewModel homeViewModel;

    [ObservableProperty]
    ObservableObject currentPageViewModel;

    [RelayCommand]
    void OpenTestView(object test)
    {
        CurrentPageViewModel = new TestViewModel(test as Test);
    }

    [RelayCommand]
    void GoToHomeView()
    {
        CurrentPageViewModel = homeViewModel;
    }
}
