using System.Collections.Specialized;
using System.ComponentModel;
using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    public bool IsDirty = false;

    [ObservableProperty]
    TeacherTest test;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    int selIndex;

    public ObservableCollection<Question> Questions { get; set; } = new();

    [ObservableProperty]
    INavigationService navigation;

    public EditTestViewModel(TeacherTest test, INavigationService navigation)
    {
        Questions.CollectionChanged += Questions_CollectionChanged;

        Navigation = navigation;
        Test = test;
        BackupTest();
    }

    //[RelayCommand]
    //void AddQuestion() => Questions.Add(new Question("q", new("a"), Guid.NewGuid().ToString()));

    [RelayCommand]
    void RemAnsFromQ(object parameters)
    {
        if (parameters is object[] objs)
        {
            if (objs[0] is IManyAnswers q && objs[1] is Answer a)
            {
                q.RemAns(a);
            }
        }
    }

    [RelayCommand]
    void AddPosAnsToQ(IManyAnswers q)
    {
        q.AddPosAns();
    }

    [RelayCommand]
    void AddSAQuestion() => AddQuestion(new ShortAnswerQuestion("", false, new(""), Guid.NewGuid().ToString(), 1));

    [RelayCommand]
    void AddMCQuestion() => AddQuestion(new MultipleChoiceQuestion("", false, Guid.NewGuid().ToString(), [new("Option 1"), new("Option 2")], 1));

    [RelayCommand]
    void AddMCMQuestion() => AddQuestion(new MultipleChoiceManyQuestion("", false, Guid.NewGuid().ToString(), [new("Option 1"), new("Option 2")], 1));

    void AddQuestion(Question question)
    {
        Questions.Insert(Questions.Count == 0 ? Questions.Count : SelIndex + 1, question);
        SelIndex = Math.Min(SelIndex + 1, Questions.Count - 1);
    }

    [RelayCommand]
    void RemoveQuestion(Question q) => Questions.Remove(q);

    [RelayCommand]
    void Save()
    {
        SaveChanges(out _);
    }

    public void SaveChanges(out bool success)
    {
        if (!CanSave())
        {
            success = false;
            return;
        }
        Test.Name = Name;
        Test.Questions.Clear();
        foreach (Question question in Questions)
        {
            Test.Questions.Add(question.DeepCopy());
        };

        success = true;
        IsDirty = false;
    }

    bool CanSave()
    {
        if (!Questions.OfType<IManyAnswers>().All(x => x.PossibleAnswers.Any(y => y.IsCorrect)))
        {
            MessageBox.Show("Not all questions have a selected answer.... u stooooopid");
            return false;
        }

        if (Questions.OfType<IManyAnswers>().Any(x => x.PossibleAnswers.Select(y => y.Text).ToHashSet().Count != x.PossibleAnswers.Count))
        {
            MessageBox.Show("All options must be unique");
            return false;
        }

        return true;
    }

    [RelayCommand]
    void Cancel()
    {
        BackupTest();
    }

    [RelayCommand]
    void Back() 
    {
        bool savesuccess = true;
        if (IsDirty)
        {
            var result = MessageBox.Show("You have unsaved changes!", Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveChanges(out savesuccess);
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    return;
            }
        }
        if (savesuccess) Navigation.NavigateTo<TestViewModel, Test>(Test);
    }

    void BackupTest()
    {
        Name = Test.DeepCopy().Name;
        Questions.Clear();
        foreach (Question question in Test.DeepCopy().Questions)
        {
            Questions.Add(question.DeepCopy());
        }

        IsDirty = false;
    }

    void Questions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        IsDirty = true;

        if (e.OldItems != null)
            foreach (Question oldItem in e.OldItems)
            {
                oldItem.PropertyChanged -= Question_PropertyChanged;
                if (oldItem is ISingleAnswer o)
                {
                    o.Answer.PropertyChanged -= Question_PropertyChanged;
                }
                if (oldItem is IManyAnswers question)
                { 
                    question.PossibleAnswers.CollectionChanged -= Answers_CollectionChanged;
                    foreach (Answer posans in question.PossibleAnswers)
                        posans.PropertyChanged -= Question_PropertyChanged;
                }
            }

        if (e.NewItems != null)
            foreach (Question newItem in e.NewItems)
            {
                newItem.PropertyChanged += Question_PropertyChanged;
                if (newItem is ISingleAnswer o)
                {
                    o.Answer.PropertyChanged += Posans_PropertyChanged;
                }
                if (newItem is IManyAnswers question)
                {
                    question.PossibleAnswers.CollectionChanged += Answers_CollectionChanged;
                    foreach (Answer posans in question.PossibleAnswers)
                        posans.PropertyChanged += Posans_PropertyChanged; ;
                }
            }
    }

    void Answers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        IsDirty = true;

        if (e.OldItems != null)
            foreach (Answer oldItem in e.OldItems)
            {
                oldItem.PropertyChanged -= Posans_PropertyChanged;
            }

        if (e.NewItems != null)
            foreach (Answer newItem in e.NewItems)
            {
                newItem.PropertyChanged += Posans_PropertyChanged;
            }
    }

    void Question_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        IsDirty = true;
    }

    void Posans_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        IsDirty = true;
    }

    partial void OnNameChanging(string? oldValue, string newValue)
    {
        IsDirty = true;
    }
}
