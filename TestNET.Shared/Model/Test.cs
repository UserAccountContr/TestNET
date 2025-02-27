namespace TestNET.Shared.Model;

public class Test
{
    public string Name { get; set; }

    public ObservableCollection<Question> Questions { get; set; } = new();

    public override string ToString() => Name;

    public Test(string name, ObservableCollection<Question> questions)
    {
        Name = name;
        Questions = questions;
    }

    public Test DeepCopy() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.DeepCopy())));

    public Test WithoutAnswers() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.WithoutAnswers())));
}

public class TeacherTest : Test
{
    public ObservableCollection<Submission> Submissions { get; set; } = new();
    public bool Shuffled { get; set; }

    public TeacherTest(string name, ObservableCollection<Question> questions, ObservableCollection<Submission> submissions, bool shuffled) : base(name, questions)
    {
        Shuffled = shuffled;
        Submissions = submissions ?? new();
    }

    public float Grade(ref Submission subm)
    {
        float msg = 0;
        foreach (Question question in subm.Answers.Questions)
        {
            if (question is ISingleAnswer)
            {
                question.Points = ((ISingleAnswer)Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((ISingleAnswer)question).Answer);
                msg += question.Points;
            }
            else if (question is IManyAnswers)
            {
                question.Points = ((IManyAnswers)Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((IManyAnswers)question).PossibleAnswers);

                if (question.Points == 0) subm.RequiresAttention = true;

                msg += question.Points;
            }
        }

        return msg;
    }

    //public Test GenerateTest(options) { }
}