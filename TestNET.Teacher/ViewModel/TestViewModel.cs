using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(Test test)
    {
        Test = test;
        testService = new TestService();
    }

    TestService testService;

    [ObservableProperty]
    Test test;

    [RelayCommand]
    void ShareTest()
    {
        IsBusy = true;
        testService.ShareTest(test);
    }

    [RelayCommand]
    void StopSharingTest()
    {
        testService.StopSharingTest();
        IsBusy = false;
    }
}
