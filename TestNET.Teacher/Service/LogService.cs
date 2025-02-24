namespace TestNET.Teacher.Service;

public partial class LogService : ObservableObject
{
    [ObservableProperty]
    string testLog;

    [ObservableProperty]
    string iPCode;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TestNotStarted))]
    bool testStarted = false;

    public bool TestNotStarted => !TestStarted;
}
