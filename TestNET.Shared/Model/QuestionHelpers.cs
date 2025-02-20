namespace TestNET.Shared.Model;

public static class QuestionHelpers
{
    public static Question DeepCopy(this Question q) => q switch
    {
        MultipleChoiceManyQuestion mcmany => new MultipleChoiceManyQuestion(mcmany.Text, mcmany.TextIsMath, mcmany.UniqueId, [.. mcmany.PossibleAnswers.Select(x => x.DeepCopy())], mcmany.Points),
        MultipleChoiceQuestion mc => new MultipleChoiceQuestion(mc.Text, mc.TextIsMath, mc.UniqueId, [.. mc.PossibleAnswers.Select(x => x.DeepCopy())], mc.Points),
        ShortAnswerQuestion sh => new ShortAnswerQuestion(sh.Text, sh.TextIsMath, sh.Answer.DeepCopy(), sh.UniqueId, sh.Points),
        _ => throw new NotImplementedException()
    };

    public static Question WithoutAnswers(this Question q) => q switch
    {
        MultipleChoiceManyQuestion mcmany => new MultipleChoiceManyQuestion(mcmany.Text, mcmany.TextIsMath, mcmany.UniqueId, [.. mcmany.PossibleAnswers.Select(x => x.WithoutAnswer())], mcmany.Points),
        MultipleChoiceQuestion mc => new MultipleChoiceQuestion(mc.Text, mc.TextIsMath, mc.UniqueId, [.. mc.PossibleAnswers.Select(x => x.WithoutAnswer())], mc.Points),
        ShortAnswerQuestion sh => new ShortAnswerQuestion(sh.Text, sh.TextIsMath, new(""), sh.UniqueId, sh.Points),
        _ => throw new NotImplementedException()
    };

    //public static string QType(this Question q) => q switch
    //{
    //    ShortAnswerQuestion => "SH",
    //    MultipleChoiceQuestion => "MC",
    //    MultipleChoiceManyQuestion => "MCM",
    //    _ => "unknown"
    //};

    //public static float Grade(this Question q, ObservableCollection<Answer> submAnswers) => q switch
    //{
    //    MultipleChoiceManyQuestion mcmany => mcmany.Grade(submAnswers),
    //    MultipleChoiceQuestion mc => mc.Grade(submAnswers),
    //    _ => throw new NotImplementedException()
    //};

    public static void AddPosAns(this IManyAnswers q) => q.PossibleAnswers.Add(new($"Option {q.PossibleAnswers.Count + 1}"));
    public static void RemAns(this IManyAnswers q, Answer ans) => q.PossibleAnswers.Remove(ans);

    public static float MaxPoints(this Test t) => t.Questions.Sum(x => x.Points);

    public static Test NormalTest(this TeacherTest t) => new (t.Name, new ObservableCollection<Question>(t.Questions.Select(x => x.DeepCopy())));
}
