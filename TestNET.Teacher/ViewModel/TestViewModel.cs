using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(TeacherTest test, TestService testService)
    {
        Test = test;
        this.testService = testService;
    }

    TestService testService;

    [ObservableProperty]
    TeacherTest test;

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

    public string GetQuestion(string uid) => Test.Questions.Where(x => x.UniqueId == uid).FirstOrDefault().Text;
}
