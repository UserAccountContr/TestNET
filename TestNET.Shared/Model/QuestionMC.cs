namespace TestNET.Shared.Model;

public partial class MultipleChoiceQuestion : Question, IManyAnswers
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; } = new();

    public MultipleChoiceQuestion(string text, bool textIsMath, string uniqueid, ObservableCollection<Answer> possibleanswers, float points) : base(text, textIsMath, uniqueid, points)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceQuestion(Text, TextIsMath, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())), Points);

    public override Question WithoutAnswers() => new MultipleChoiceQuestion(Text, TextIsMath, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())), Points);

    public float Grade(ObservableCollection<Answer> submAnswers)
    {
        foreach (Answer a in PossibleAnswers)
        {
            if (a.IsCorrect != submAnswers.Where(x => x.Text == a.Text).First().IsCorrect)
                return 0;
        }
        return Points;

        //float p = 0;
        //float perQ = Points / PossibleAnswers.Count;
        //foreach (Answer a in PossibleAnswers)
        //{
        //    if (a.IsCorrect == submAnswers.Where(x => x.Text == a.Text).First().IsCorrect)
        //        p += perQ;
        //}
        //return p;
    }

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}

public interface IManyAnswers
{
    ObservableCollection<Answer> PossibleAnswers { get; set; }

    public float Grade(ObservableCollection<Answer> submAnswers);
}