namespace TestNET.Shared.Model;

public class Question
{
    public string Text { get; set; }

    public string Answer { get; set; }
}

public class MultipleChoiceQuestion : Question
{
    public string[] PossibleAnswers { get; set; }
}