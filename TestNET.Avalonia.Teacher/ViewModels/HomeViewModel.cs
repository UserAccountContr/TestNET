using TestNET.Avalonia.Teacher.Service;
namespace TestNET.Avalonia.Teacher.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<TeacherTest> Tests { get; } = new();
    TestService testService;
    ISettingsService settingsService;
    INavigationService Navigation;
    //public string Greeting => "Welcome to Avalonia!";

    public HomeViewModel(TestService testService, ISettingsService settings, INavigationService navigation)
    {
        this.testService = testService;
        settingsService = settings;
        Navigation = navigation;
    }
    
    [RelayCommand]
    void OpenTestView(object test) => Navigation.NavigateTo<TestViewModel, Test>(test as Test);

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new TeacherTest("New test", new(), new(), false));
        //Navigation.NavigateTo<EditTestViewModel, Test>(Tests[^1]);
    }

    [RelayCommand]
    void RemoveTest(object selitem)
    {
        Tests.Remove((TeacherTest)selitem);
        testService.DeleteTest((TeacherTest)selitem);
    }

//    [RelayCommand]
//    void ImportTest() 
//    {
//        OpenFileDialog openFileDialog = new OpenFileDialog();
//        openFileDialog.Filter = "Test Database Files | *.db";
//
//        if (openFileDialog.ShowDialog() == true)
//        {
//            var test = testService.ImportTest(openFileDialog.FileName);
//
//            if (test != null)
//            {
//                Tests.Add(test);
//            }
//        }
//    }

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

}
