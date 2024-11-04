using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Test> Tests { get; } = new();
    TestService testService;

    public HomeViewModel()
    {
        this.testService = new TestService();
    }

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new Test
        {
            Name = "Test1",
            Questions = new()
            {
                new MultipleChoiceQuestion
                {
                    Text = "Q1",
                    Answer = "A1",
                    PossibleAnswers =
                    [
                        "Slay",
                        "Brat",
                        "Queen",
                        "Yesh"
                    ]
                },
                new MultipleChoiceQuestion
                {
                    Text = "Q2",
                    Answer = "A2",
                    PossibleAnswers =
                    [
                        "Slay",
                        "Brat",
                        "Queen",
                        "Yesh"
                    ]
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
    async Task LoadTest()
    {
        Tests.Clear();
        var tests = await testService.GetTests();
        foreach (var test in tests)
        {
            Tests.Add(test);
        }
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
