namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    [ObservableProperty]
    Test test;

    [ObservableProperty]
    string name;

    public ObservableCollection<Question> Questions { get; set; } = new();

    public EditTestViewModel(Test test)
    {
        Test = test;
        BackupTest();
    }

    [RelayCommand]
    void AddQuestion() => Questions.Add(new Question("q", "a"));

    [RelayCommand]
    void SaveChanges()
    {
        Test.Name = Name;
        Test.Questions.Clear();
        foreach (Question question in Questions)
        {
            Test.Questions.Add(question.DeepCopy());
        };
    }

    [RelayCommand]
    void Cancel()
    {
        BackupTest();
    }

    void BackupTest()
    {
        Name = Test.DeepCopy().Name;
        Questions.Clear();
        foreach (Question question in Test.DeepCopy().Questions)
        {
            Questions.Add(question.DeepCopy());
        }
    }
}
