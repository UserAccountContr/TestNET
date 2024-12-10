namespace TestNET.Shared.Model;

public class Submission
{
    public string Name { get; set; }

    public Dictionary<string, Answer> Answers { get; set; }

    public DateTime TimeSubmitted { get; set; }

    public Submission(string name, Dictionary<string, Answer> answers, DateTime timesubmitted)
    {
        Name = name;
        Answers = answers;
        TimeSubmitted = timesubmitted;
    }
}
