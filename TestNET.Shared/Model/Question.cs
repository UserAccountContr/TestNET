﻿using System.ComponentModel;

namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    Answer answer;

    public string UniqueId { get; set; } = Guid.NewGuid().ToString();

    public Question(string text, Answer answer)
    {
        Text = text;
        Answer = answer;
    }

    public virtual Question DeepCopy() => new Question(Text, Answer.DeepCopy());

    public virtual Question WithoutAnswers() => new Question(Text, new(""));
}

public partial class MultipleChoiceQuestion : Question
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, Answer answer, ObservableCollection<Answer> possibleanswers) : base(text, answer)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer.DeepCopy(), new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));

    public override Question WithoutAnswers() => new MultipleChoiceQuestion(Text, new(""), new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())));

    [RelayCommand]
    void SetCorrectAnswer(Answer answer)
    {
        Answer = answer;
    }

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}

public partial class Answer : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    bool isCorrect;

    public Answer(string text)
    {
        Text = text;
    }

    public Answer DeepCopy() => new(Text) { IsCorrect = IsCorrect };
    public Answer WithoutAnswer() => new(Text) { IsCorrect = false };
}