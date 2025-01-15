﻿using System.Collections.Specialized;
using System.ComponentModel;
using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    bool IsDirty = false;

    [ObservableProperty]
    TeacherTest test;

    [ObservableProperty]
    string name;

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
    void AddSAQuestion() => Questions.Add(new ShortAnswerQuestion("", false, new(""), Guid.NewGuid().ToString(), 1));

    [RelayCommand]
    void AddMCQuestion() => Questions.Add(new MultipleChoiceQuestion("", false, Guid.NewGuid().ToString(), new(), 1));

    [RelayCommand]
    void AddMCMQuestion() => Questions.Add(new MultipleChoiceManyQuestion("", false, Guid.NewGuid().ToString(), new(), 1));

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

        IsDirty = false;
    }

    [RelayCommand]
    void Cancel()
    {
        BackupTest();
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
