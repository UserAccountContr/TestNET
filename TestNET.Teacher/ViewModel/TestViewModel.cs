using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public ObservableCollection<Test> Tests { get; } = new();
    TestService testService;

    public TestViewModel()
    {
        this.testService = new TestService();
    }

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new Test
        {
            Name = "Test1",
            Questions = new List<Question>()
            {
                new Question
                {
                    Text = "Q1",
                    Answer = "A1"
                }
            }
        });
    }

    [RelayCommand]
    void RemoveTest(object selitem)
    {
        Tests.Remove(selitem as Test);
    }

    [RelayCommand]
    void SaveTest()
    {
        testService.SaveTests(Tests.ToList());
    }

    [RelayCommand]
    async void LoadTest()
    {
        var tests = await testService.GetTests();
        foreach (var test in tests)
        {
            Tests.Add(test);
        }
    }
}
