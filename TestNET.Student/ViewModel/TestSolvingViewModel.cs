using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class TestSolvingViewModel : BaseViewModel
{
    public TestSolvingViewModel(Test test, TestService testService)
    {
        this.testService = testService;
        Test = test;
    }

    TestService testService;

    [ObservableProperty]
    Test test;

    [RelayCommand]
    void Submit()
    {
        testService.ReturnTest(Test.DeepCopy());
    }
}
