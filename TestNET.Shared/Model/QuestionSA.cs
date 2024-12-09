namespace TestNET.Shared.Model;

public partial class ShortAnswerQuestion : Question
{
    //[ObservableProperty]
    //Answer answer;

    public ShortAnswerQuestion(string text, Answer answer, string uniqueid) : base(text, answer, uniqueid)
    {

    }

    public override Question DeepCopy() => new ShortAnswerQuestion(Text, Answer.DeepCopy(), UniqueId);

    public override Question WithoutAnswers() => new ShortAnswerQuestion(Text, new(""), UniqueId);
}
