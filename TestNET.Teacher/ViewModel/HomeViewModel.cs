using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Test> Tests { get; } = new();
    TestService testService;
    ISettingsService settingsService;

    public HomeViewModel(TestService testService, ISettingsService settings)
    {
        this.testService = testService;
        settingsService = settings;
    }

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new Test
        {
            Name = "Test1",
            Questions = new()
            {
                new MultipleChoiceQuestion("Q1", new("A1"), [new("Slay"), new("Yes"), new("Thats on period")]),
                new MultipleChoiceQuestion("Q2", new("A2"), [new("Slay"), new("Yes"), new("Thats on period")]),
                new MultipleChoiceQuestion("Q3", new("A3"), [new("Yass")])
            }
        });
    }

    [RelayCommand]
    void RemoveTest(object selitem) => Tests.Remove(selitem as Test);

    [RelayCommand]
    void SaveTest() => testService.SaveTests(Tests.ToList());

    [RelayCommand]
    async Task LoadTest()
    {
        Tests.Clear();
        var tests = await testService.GetTests();
        foreach (var test in tests)
        {
            Tests.Add(test);
        }
    }


    [RelayCommand]
    void SetLang(string lang)
    {
        settingsService.ChangeLanguage(lang);
    }

    [RelayCommand]
    void SetTheme(string style)
    {
        settingsService.ChangeTheme(style);
    }

    //[RelayCommand]
    //void ShowTest(object test)
    //{
    //    if (test != null && test is Test)
    //    {
    //        //Test test1 = (Test)test;
    //        //if (test1.Questions[0] is MultipleChoiceQuestion)
    //        //    MessageBox.Show($"Q: {test1.Questions[0].Text}\nA: {test1.Questions[0].Answer}\n {string.Join(" ", (test1.Questions[0] as MultipleChoiceQuestion).PossibleAnswers)}", test1.Name);
    //        //else
    //        //    MessageBox.Show($"Q: {test1.Questions[0].Text}\nA: {test1.Questions[0].Answer}", test1.Name);
    //        
    //
    //    }
    //}
}
