﻿namespace TestNET.Shared.Model;

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

    public void AddQuestion() => Questions.Add(new Question("q", new("a")));

    public Test DeepCopy() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.DeepCopy())));

    public Test WithoutAnswers() => new Test(Name, new ObservableCollection<Question>(Questions.Select(x => x.WithoutAnswers())));
}
