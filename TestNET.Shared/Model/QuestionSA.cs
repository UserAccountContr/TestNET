namespace TestNET.Shared.Model;

public partial class ShortAnswerQuestion : Question, ISingleAnswer
{
    [ObservableProperty]
    Answer answer;

    public ShortAnswerQuestion(string text, Answer answer, string uniqueid) : base(text, uniqueid)
    {
        Answer = answer;
    }

    public override Question DeepCopy() => new ShortAnswerQuestion(Text, Answer.DeepCopy(), UniqueId);

    public override double Grade(Answer answer)
    {
        throw new NotImplementedException();
    }

    public override Question WithoutAnswers() => new ShortAnswerQuestion(Text, new(""), UniqueId);
}

public interface ISingleAnswer
{
    Answer Answer { get; set; }
}