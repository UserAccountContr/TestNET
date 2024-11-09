namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public class Question
{
    public string Text { get; set; }

    public string Answer { get; set; }

    public string UniqueId { get; set; } = Guid.NewGuid().ToString();

    public Question(string text, string answer)
    {
        Text = text;
        Answer = answer;
    }

    public virtual Question DeepCopy() => new Question(Text, Answer);
}

public class MultipleChoiceQuestion : Question
{
    public string[] PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, string answer, string[] possibleanswers) : base(text, answer)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer, PossibleAnswers);
}