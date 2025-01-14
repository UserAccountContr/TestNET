﻿namespace TestNET.Shared.Model;

public partial class ShortAnswerQuestion : Question, ISingleAnswer
{
    [ObservableProperty]
    Answer answer;

    public ShortAnswerQuestion(string text, Answer answer, string uniqueid, float points) : base(text, uniqueid, points)
    {
        Answer = answer;
    }

    public override Question DeepCopy() => new ShortAnswerQuestion(Text, Answer.DeepCopy(), UniqueId, Points);

    public override Question WithoutAnswers() => new ShortAnswerQuestion(Text, new(""), UniqueId, Points);

    public float Grade(Answer submAnswer)
    {
        if (submAnswer.Text == Answer.Text) return Points;
        else return 0;
    }
}

public interface ISingleAnswer
{
    Answer Answer { get; set; }

    public float Grade(Answer submAnswer);
}