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
        Name = test.DeepCopy().Name;
        Questions = new ObservableCollection<Question>(test.DeepCopy().Questions);
    }

    [RelayCommand]
    void AddQuestion() => Test.AddQuestion();

    [RelayCommand]
    void SaveChanges()
    {
        Test.Name = Name;
        Test.Questions = Questions;
    }

    [RelayCommand]
    void Cancel()
    {
        Name = Test.DeepCopy().Name;
        Questions.Clear();
        foreach (Question question in Test.DeepCopy().Questions)
        {
            Questions.Add(question);
        }
    }
}
