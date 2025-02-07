namespace TestNET.Shared.Model;

public class Submission
{
    public string Name { get; set; }

    public Test Answers { get; set; }

    public DateTime TimeSubmitted { get; set; }

    public float Points { get; set; }

    public Submission(string name, Test answers, DateTime timesubmitted, float points = 0)
    {
        Name = name;
        Answers = answers;
        TimeSubmitted = timesubmitted;
        Points = points;
    }
}
