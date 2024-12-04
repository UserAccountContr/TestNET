namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multipleChoice")]
public partial class Question : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    Answer answer;

    public string UniqueId { get; set; }

    public Question(string text, Answer answer, string uid)
    {
        Text = text;
        Answer = answer;
        UniqueId = uid;
    }

    public virtual Question DeepCopy() => new Question(Text, Answer.DeepCopy(), UniqueId);

    public virtual Question WithoutAnswers() => new Question(Text, new(""), UniqueId);
}

public partial class MultipleChoiceQuestion : Question
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; }

    public MultipleChoiceQuestion(string text, Answer answer, string uid, ObservableCollection<Answer> possibleanswers) : base(text, answer, uid)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer.DeepCopy(), UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));

    public override Question WithoutAnswers() => new MultipleChoiceQuestion(Text, new(""), UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())));

    [RelayCommand]
    void SetCorrectAnswer(Answer answer)
    {
        Answer = answer;
    }

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}

public partial class Answer : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    bool isCorrect;

    public Answer(string text)
    {
        Text = text;
    }

    public Answer DeepCopy() => new(Text) { IsCorrect = IsCorrect };
    public Answer WithoutAnswer() => new(Text) { IsCorrect = false };
}