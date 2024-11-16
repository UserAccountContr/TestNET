﻿namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public class Question
{
    public string Text { get; set; }

    public Answer Answer { get; set; }

    public string UniqueId { get; set; } = Guid.NewGuid().ToString();

    public Question(string text, Answer answer)
    {
        Text = text;
        Answer = answer;
    }

    public virtual Question DeepCopy() => new Question(Text, Answer);
}

public partial class MultipleChoiceQuestion : Question
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, Answer answer, ObservableCollection<Answer> possibleanswers) : base(text, answer)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));

    [RelayCommand]
    void SetCorrectAnswer(Answer answer)
    {
        Answer = answer;
    }
}

public partial class Answer : ObservableObject
{
    public string Text { get; set; }

    [ObservableProperty]
    bool isCorrect;

    public Answer(string text)
    {
        Text = text;
    }

    public Answer DeepCopy() => new(Text) { IsCorrect = IsCorrect};
}