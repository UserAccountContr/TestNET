namespace TestNET.Shared.Model;

public class Submission
{
    public string Name { get; set; }

    public string Code { get; set; }

    public Test Answers { get; set; }

    public Test? CorrectAnswers { get; set; }

    public DateTime TimeSubmitted { get; set; }

    public float Points { get; set; }

    public bool RequiresAttention { get; set; }

    public Submission(string name, Test answers, DateTime timesubmitted, float points = 0, Test? correctAnswers = null, string code = "", bool attention = false)
    {
        Name = name;
        Answers = answers;
        CorrectAnswers = correctAnswers;
        TimeSubmitted = timesubmitted;
        Points = points;
        Code = code;
        RequiresAttention = attention;
    }
}
