using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(Test test, TestService testService)
    {
        Test = test;
        this.testService = testService;
    }

    TestService testService;

    [ObservableProperty]
    Test test;

    [RelayCommand]
    void ShareTest()
    {
        IsBusy = true;
        testService.ShareTest(Test);
    }

    [RelayCommand]
    void StopSharingTest()
    {
        testService.StopSharingTest();
        IsBusy = false;
    }
}
