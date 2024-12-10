namespace TestNET.Shared.Model;

public class Test
{
    public string Name { get; set; }

    public ObservableCollection<Question> Questions { get; set; }

    public override string ToString() => Name;

    public Test(string name, ObservableCollection<Question> questions)
    {
        Name = name;
        Questions = questions;
    }

    //public void AddQuestion() => Questions.Add(new Question("q", new("a"), Guid.NewGuid().ToString()));

    public Test DeepCopy() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.DeepCopy())));

    public Test WithoutAnswers() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.WithoutAnswers())));
}

public class TeacherTest : Test
{
    public ObservableCollection<Submission> Submissions { get; set; }

    public TeacherTest(string name, ObservableCollection<Question> questions, ObservableCollection<Submission> submissions) : base(name, questions)
    {
        Submissions = submissions;
    }

    //public Test GenerateTest(options) { }
}