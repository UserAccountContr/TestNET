using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    bool IsDirty { get => !(Test.Name.Equals(Name) && Test.Questions.Equals(Questions)); }

    [ObservableProperty]
    Test test;

    [ObservableProperty]
    string name;

    public ObservableCollection<Question> Questions { get; set; } = new();

    [ObservableProperty]
    INavigationService navigation;

    public EditTestViewModel(Test test, INavigationService navigation)
    {
        Navigation = navigation;
        Test = test;
        BackupTest();
    }
    
    [RelayCommand]
    void AddQuestion() => Questions.Add(new Question("q", new("a")));

    [RelayCommand]
    void SaveChanges()
    {
        if (!Questions.OfType<MultipleChoiceQuestion>().All(x => x.PossibleAnswers.Any(y => y.IsCorrect)))
        {
            MessageBox.Show("Not all questions have a selected answer.... u stooooopid");
            return;
        }
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

    [RelayCommand]
    void Back() 
    {
        if (IsDirty)
        {
            var result = MessageBox.Show("You have unsaved changes!", Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveChanges();
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    return;
            }
        }
        Navigation.NavigateTo<TestViewModel, Test>(Test); 
    }
}
