namespace TestNET.Shared.Model;

public class Question
{
    public string Text { get; set; }

    public string Answer { get; set; }

    public string UniqueId { get; set; } = Guid.NewGuid().ToString();
}

public class MultipleChoiceQuestion : Question
{
    public string[] PossibleAnswers { get; set; }
}