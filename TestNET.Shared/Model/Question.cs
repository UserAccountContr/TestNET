namespace TestNET.Shared.Model;

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
}

public class MultipleChoiceQuestion : Question
{
    public string[] PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, string answer) : base(text, answer)
    {
    }
}