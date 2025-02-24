using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(TeacherTest test, TestService testService, LogService logService)
    {
        Test = test;
        this.testService = testService;
        LogService = logService;
        Log = "";
    }

    private TestService testService;

    public ShortAnswerQuestion Testq => new ShortAnswerQuestion("",false, new Answer(""),"", 1);
    public LogService LogService { get; }

    [ObservableProperty]
    string log;

    [ObservableProperty]
    TeacherTest test;

    [RelayCommand]
    void ShareTest()
    {
        IsBusy = true;
        testService.StartSharingTest(Test);
    }

    [RelayCommand]
    void StopSharingTest()
    {
        testService.StopSharingTest();
        IsBusy = false;
    }

    public string GetQuestion(string uid) => Test.Questions.Where(x => x.UniqueId == uid).FirstOrDefault().Text;
}
