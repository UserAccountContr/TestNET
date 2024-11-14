using System.Collections.Specialized;

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
    public ObservableCollection<Answer> PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, string answer, ObservableCollection<Answer> possibleanswers) : base(text, answer)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));
}

public class Answer
{
    public string Text { get; set; }

    public Answer(string text)
    {
        Text = text;
    }

    public Answer DeepCopy() => new(Text);
}