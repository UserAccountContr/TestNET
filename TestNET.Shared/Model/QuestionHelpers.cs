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

    public static void MoveUpAns(this IManyAnswers q, Answer ans)
    {
        int index = q.PossibleAnswers.IndexOf(ans);

        if (index == 0)
        {
            return;
        }

        bool correctSelected = q.PossibleAnswers[index].IsCorrect;
        bool correctTarget = q.PossibleAnswers[index - 1].IsCorrect;

        (q.PossibleAnswers[index - 1], q.PossibleAnswers[index]) = (q.PossibleAnswers[index], q.PossibleAnswers[index - 1]);

        q.PossibleAnswers[index].IsCorrect = correctTarget;
        q.PossibleAnswers[index - 1].IsCorrect = correctSelected;
    }

    public static void MoveDownAns(this IManyAnswers q, Answer ans)
    {
        int index = q.PossibleAnswers.IndexOf(ans);

        if (index == q.PossibleAnswers.Count - 1)
        {
            return;
        }

        bool correctSelected = q.PossibleAnswers[index].IsCorrect;
        bool correctTarget = q.PossibleAnswers[index + 1].IsCorrect;

        (q.PossibleAnswers[index], q.PossibleAnswers[index + 1]) = (q.PossibleAnswers[index + 1], q.PossibleAnswers[index]);

        q.PossibleAnswers[index].IsCorrect = correctTarget;
        q.PossibleAnswers[index + 1].IsCorrect = correctSelected;
    }

    public static float MaxPoints(this Test t) => t.Questions.Sum(x => x.Points);

    public static Test NormalTest(this TeacherTest t) => new (t.Name, new ObservableCollection<Question>(t.Questions.Select(x => x.DeepCopy())));

    public static float Grade(this Submission s)
    {
        float msg = 0;
        if (s.CorrectAnswers == null || s.CorrectAnswers.Questions.Count == 0) return 0;
        foreach (Question question in s.Answers.Questions)
        {
            if (question is ISingleAnswer)
            {
                question.Points = ((ISingleAnswer)s.CorrectAnswers.Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((ISingleAnswer)question).Answer);
                msg += question.Points;
            }
            else if (question is IManyAnswers)
            {
                question.Points = ((IManyAnswers)s.CorrectAnswers.Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((IManyAnswers)question).PossibleAnswers);
                msg += question.Points;
            }
        }
        return msg;
    }
}
