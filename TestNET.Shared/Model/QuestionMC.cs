namespace TestNET.Shared.Model;

public partial class MultipleChoiceQuestion : Question, IManyAnswers
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; } = new();

    public MultipleChoiceQuestion(string text, string uniqueid, ObservableCollection<Answer> possibleanswers) : base(text, uniqueid)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())));

    public override Question WithoutAnswers() => new MultipleChoiceQuestion(Text, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())));

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}

public interface IManyAnswers
{
    ObservableCollection<Answer> PossibleAnswers { get; set; }
}