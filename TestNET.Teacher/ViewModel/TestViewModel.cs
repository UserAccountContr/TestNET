using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(Test test)
    {
        this.test = test;
        testService = new TestService();
    }

    TestService testService;

    [ObservableProperty]
    Test test;

    [RelayCommand]
    void ShareTest()
    {
        testService.ShareTest(test);
    }
}
