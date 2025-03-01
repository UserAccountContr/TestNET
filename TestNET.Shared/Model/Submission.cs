using System.ComponentModel;

namespace TestNET.Shared.Model;

public partial class Submission : ObservableObject
{
    public string Name { get; set; }

    public string Code { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Points))]
    Test answers;

    public Test? CorrectAnswers { get; set; }

    public DateTime TimeSubmitted { get; set; }

    public float Points => Answers.Questions.Sum(x => x.Points);
    public float MaxPoints => CorrectAnswers?.Questions.Sum(x => x.Points) ?? 0;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Points))]
    bool requiresAttention;

    public Submission(string name, Test answers, DateTime timesubmitted, Test? correctAnswers = null, string code = "", bool requiresAttention = false)
    {
        Name = name;
        Answers = answers;
        CorrectAnswers = correctAnswers;
        TimeSubmitted = timesubmitted;
        Code = code;
        RequiresAttention = requiresAttention;
    }

    public void OnPropertyChanged1(PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName);
    }
}
