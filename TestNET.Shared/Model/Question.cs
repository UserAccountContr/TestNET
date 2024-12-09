namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(ShortAnswerQuestion), typeDiscriminator: "shortAnswer")]
[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public abstract partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    Answer answer;

    public string UniqueId { get; set; }

    public Question(string text, Answer answer, string uniqueid)
    {
        Text = text;
        Answer = answer;
        UniqueId = uniqueid;
    }

    public abstract Question DeepCopy();

    public abstract Question WithoutAnswers();
}
