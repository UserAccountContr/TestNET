﻿namespace TestNET.Shared.Model;

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

    //public void AddQuestion() => Questions.Add(new Question("q", new("a"), Guid.NewGuid().ToString()));

    public Test DeepCopy() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.DeepCopy())));

    public Test WithoutAnswers() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.WithoutAnswers())));
}

public class TeacherTest : Test
{
    public ObservableCollection<Submission> Submissions { get; set; } = new();

    public TeacherTest(string name, ObservableCollection<Question> questions, ObservableCollection<Submission> submissions) : base(name, questions)
    {
        Submissions = submissions ?? new();
    }
    public void Grade(Submission subm)
    {
        string msg = "";
        foreach (Question question in subm.Answers.Questions)
        {
            if (question is ISingleAnswer)
            {
                msg += ((ISingleAnswer)Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((ISingleAnswer)question).Answer);
            }
            else if (question is IManyAnswers)
            {
                msg += ((IManyAnswers)Questions.Where(x => x.UniqueId == question.UniqueId).First()).Grade(((IManyAnswers)question).PossibleAnswers);
            }
        }
        MessageBox.Show(msg);
    }

    //public Test GenerateTest(options) { }
}