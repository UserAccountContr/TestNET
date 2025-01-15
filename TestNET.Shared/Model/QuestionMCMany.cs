namespace TestNET.Shared.Model;

public partial class MultipleChoiceManyQuestion : Question, IManyAnswers
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; } = new();

    public MultipleChoiceManyQuestion(string text, string uniqueid, ObservableCollection<Answer> possibleanswers, float points) : base(text, uniqueid, points)
    {
        PossibleAnswers = possibleanswers;
    }

    public override Question DeepCopy() => new MultipleChoiceManyQuestion(Text, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())), Points);

    public override Question WithoutAnswers() => new MultipleChoiceManyQuestion(Text, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())), Points);

    public float Grade(ObservableCollection<Answer> submAnswers)
    {
        int actuallycorrect = PossibleAnswers.Where(x => x.IsCorrect).Count();
        int userthinksarecorrect = submAnswers.Where(x => x.IsCorrect).Count();

        float p = 0;

        float perQ = Points / actuallycorrect;

        foreach (Answer a in PossibleAnswers)
        {
            if (a.IsCorrect && submAnswers.Where(x => x.Text == a.Text).First().IsCorrect)
                p += perQ;

            if (actuallycorrect < submAnswers.Where(x => x.IsCorrect).Count())
                if (!a.IsCorrect && submAnswers.Where(x => x.Text == a.Text).First().IsCorrect)
                    p -= perQ;
        }
        return Math.Max(p, 0);
    }

    [RelayCommand]
    void AddPosAns() => PossibleAnswers.Add(new(""));
}