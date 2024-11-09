using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class WindowViewModel : BaseViewModel
{
    public WindowViewModel()
    {
        homeViewModel = new HomeViewModel();
        currentPageViewModel = homeViewModel;
        testService = new TestService();
    }

    HomeViewModel homeViewModel;

    TestService testService;

    [ObservableProperty]
    ObservableObject currentPageViewModel;

    [RelayCommand]
    void GoToHomeView() => CurrentPageViewModel = homeViewModel;

    [RelayCommand]
    async void GoToTestOverview(string name)
    {
        Test test = await testService.GetTest(name);
        if (test == null)
            return;
        CurrentPageViewModel = new TestOverviewViewModel(test);
    }

    [RelayCommand]
    void StartTest(Test test)
    {
        CurrentPageViewModel = new TestSolvingViewModel(test);
    }
}
