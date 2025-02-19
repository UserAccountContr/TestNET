namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(ShortAnswerQuestion), typeDiscriminator: "shortAnswer")]
[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
[JsonDerivedType(typeof(MultipleChoiceManyQuestion), typeDiscriminator: "multipleChoiceMany")]
public abstract partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    bool textIsMath;

    [ObservableProperty]
    float points;

    public string UniqueId { get; set; }

    public Question(string text, bool textIsMath, string uniqueid, float points)
    {
        Text = text;
        UniqueId = uniqueid;
        Points = points;
        TextIsMath = textIsMath;
    }

    //public string QType
    //{
    //    get
    //    {
    //        if (this is ShortAnswerQuestion) return "SH";
    //        if (this is MultipleChoiceQuestion) return "MC";
    //        if (this is MultipleChoiceManyQuestion) return "MCM";
    //        return "unknown";
    //    }
    //}

    //public abstract Question DeepCopy();

    //public abstract Question WithoutAnswers();
}
