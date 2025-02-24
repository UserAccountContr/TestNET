using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class TestSolvingViewModel : BaseViewModel
{
    public TestSolvingViewModel(Test test, TestService testService, INavigationService navService)
    {
        this.testService = testService;
        this.navService = navService;
        Test = test;
    }

    TestService testService;
    INavigationService navService;

    [ObservableProperty]
    Test test;

    [RelayCommand]
    async Task Submit()
    {
        if (await testService.ReturnTest(Test.DeepCopy()))
        {
            // MessageBox.Show("Test submission was successful.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            navService.NavigateTo<HomeViewModel>();
        }
    }
}
