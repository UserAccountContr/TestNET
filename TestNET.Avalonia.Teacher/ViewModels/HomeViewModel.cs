using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
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
    void OpenTestView(object test) => Navigation.NavigateTo<TestViewModel, TeacherTest>((TeacherTest)test);

    [RelayCommand]
    void NewTest()
    {
        Tests.Add(new TeacherTest("New test", new(), new(), false));
        Navigation.NavigateTo<EditTestViewModel, TeacherTest>(Tests[^1]);
    }

    [RelayCommand]
    void RemoveTest(object selitem)
    {
        Tests.Remove((TeacherTest)selitem);
        testService.DeleteTest((TeacherTest)selitem);
    }

    [RelayCommand]
    async Task ImportTest() 
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime  desktopLifetime ?  desktopLifetime.MainWindow : null);

        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            FileTypeFilter = new[] { new FilePickerFileType("Test Database Files")
            {
                Patterns = new[] { "*.db" },
                //AppleUniformTypeIdentifiers = new[] { } ,
                //MimeTypes = new[] { "image/*" }
            } },
            AllowMultiple = false
        });

        if (files.Count >= 1)
        {
            //// Open reading stream from the first file.
            //await using var stream = await files[0].OpenReadAsync();
            //using var streamReader = new StreamReader(stream);
            //// Reads all the content of file as a text.
            //var fileContent = await streamReader.ReadToEndAsync();
            
            var test = testService.ImportTest(files[0].Path.ToString());
            
            if (test != null)
            {
                Tests.Add(test);
            }
        }
        
        
        //OpenFileDialog openFileDialog = new OpenFileDialog();
        //openFileDialog.Filter = "Test Database Files | *.db";

        //if (openFileDialog.ShowDialog() == true)
        //{
        //    var test = testService.ImportTest(openFileDialog.FileName);
//
        //    if (test != null)
        //    {
        //        Tests.Add(test);
        //    }
        //}
    }

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
