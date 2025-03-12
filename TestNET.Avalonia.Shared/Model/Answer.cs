namespace TestNET.Avalonia.Shared.Model;

public partial class Answer : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    bool isCorrect;

    public Answer(string text)
    {
        Text = text;
    }

    public Answer DeepCopy() => new(Text) { IsCorrect = IsCorrect };
    public Answer WithoutAnswer() => new(Text) { IsCorrect = false };
}
