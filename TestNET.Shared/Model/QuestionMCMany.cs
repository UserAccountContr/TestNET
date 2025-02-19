namespace TestNET.Shared.Model;

public partial class MultipleChoiceManyQuestion : Question, IManyAnswers
{
    public ObservableCollection<Answer> PossibleAnswers { get; set; } = new();

    public MultipleChoiceManyQuestion(string text, bool textIsMath, string uniqueid, ObservableCollection<Answer> possibleanswers, float points) : base(text, textIsMath, uniqueid, points)
    {
        PossibleAnswers = possibleanswers;
    }

    //public override Question DeepCopy() => new MultipleChoiceManyQuestion(Text, TextIsMath, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.DeepCopy())), Points);

    //public override Question WithoutAnswers() => new MultipleChoiceManyQuestion(Text, TextIsMath, UniqueId, new ObservableCollection<Answer>(PossibleAnswers.Select(x => x.WithoutAnswer())), Points);

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

    //[RelayCommand]
    //void AddPosAns() => PossibleAnswers.Add(new($"Option {PossibleAnswers.Count + 1}"));
    //
    //[RelayCommand]
    //void RemAns(Answer ans) => PossibleAnswers.Remove(ans);
}