namespace TestNET.Student.ViewModel;

public partial class WindowViewModel : BaseViewModel
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
    void GoToHomeView()
    {
        CurrentPageViewModel = homeViewModel;
    }
}
