namespace TestNET.Shared.Model;

public class Submission
{
    public string Name { get; set; }

    public Test Answers { get; set; }

    public Test? CorrectAnswers { get; set; }

    public DateTime TimeSubmitted { get; set; }

    public float Points { get; set; }

    public Submission(string name, Test answers, DateTime timesubmitted, float points = 0, Test? currentAnswers = null)
    {
        Name = name;
        Answers = answers;
        CorrectAnswers = currentAnswers;
        TimeSubmitted = timesubmitted;
        Points = points;
    }
}
