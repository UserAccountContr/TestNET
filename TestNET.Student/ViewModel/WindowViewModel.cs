using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class WindowViewModel : BaseViewModel
{
    public WindowViewModel(INavigationService navigationService, TestService testService)
    {
        Navigation = navigationService;
        this.testService = testService;
        GoToHomeView();

        //homeViewModel = new HomeViewModel();
        //currentPageViewModel = homeViewModel;
    }

    [ObservableProperty]
    INavigationService navigation;
    TestService testService;

    [RelayCommand]
    void GoToHomeView() => Navigation.NavigateTo<HomeViewModel>();

    [RelayCommand]
    async void GoToTestOverview(string name)
    {
        Test test = await testService.GetTest(name);
        if (test == null)
            return;
        Navigation.NavigateTo<TestOverviewViewModel, Test>(test);
    }

    [RelayCommand]
    void StartTest(Test test) => Navigation.NavigateTo<TestSolvingViewModel, Test>(test);

    //HomeViewModel homeViewModel;
    //
    //TestService testService;
    //
    //[ObservableProperty]
    //ObservableObject currentPageViewModel;

    //[RelayCommand]
    //void GoToHomeView() => CurrentPageViewModel = homeViewModel;

    //[RelayCommand]
    //async void GoToTestOverview(string name)
    //{
    //    Test test = await testService.GetTest(name);
    //    if (test == null)
    //        return;
    //    CurrentPageViewModel = new TestOverviewViewModel(test);
    //}

    //[RelayCommand]
    //void StartTest(Test test)
    //{
    //    CurrentPageViewModel = new TestSolvingViewModel(test);
    //}
}
