namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(ShortAnswerQuestion), typeDiscriminator: "shortAnswer")]
[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
[JsonDerivedType(typeof(MultipleChoiceManyQuestion), typeDiscriminator: "multipleChoiceMany")]
public abstract partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    float points;

    public string UniqueId { get; set; }

    public Question(string text, string uniqueid, float points)
    {
        Text = text;
        UniqueId = uniqueid;
        Points = points;
    }

    public abstract Question DeepCopy();

    public abstract Question WithoutAnswers();
}
