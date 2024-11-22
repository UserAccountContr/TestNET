using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Test> Tests { get; } = new();
    TestService testService;
    ISettingsService settingsService;
    INavigationService Navigation;

    public HomeViewModel(TestService testService, ISettingsService settings, INavigationService navigation)
    {
        this.testService = testService;
        settingsService = settings;
        Navigation = navigation;
    }

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new Test("New test", new()));
        Navigation.NavigateTo<EditTestViewModel, Test>(Tests[^1]);
    }

    [RelayCommand]
    void RemoveTest(object selitem) => Tests.Remove((Test)selitem);

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
