namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(ShortAnswerQuestion), typeDiscriminator: "shortAnswer")]
[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public abstract partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    public string UniqueId { get; set; }

    public Question(string text, string uniqueid)
    {
        Text = text;
        UniqueId = uniqueid;
    }

    public abstract double Grade(Answer answer);

    public abstract Question DeepCopy();

    public abstract Question WithoutAnswers();
}
