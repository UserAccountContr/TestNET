namespace TestNET.Shared.Model;

public partial class MultipleChoiceQuestion : Question
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; } = new();

    public MultipleChoiceQuestion(string text, Answer answer, string uniqueid, ObservableCollection<Answer> possibleanswers) : base(text, answer, uniqueid)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, Answer.DeepCopy(), UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));

    public override Question WithoutAnswers() => new MultipleChoiceQuestion(Text, new(""), UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())));

    [RelayCommand]
    void SetCorrectAnswer(Answer answer) => Answer = answer;

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}
