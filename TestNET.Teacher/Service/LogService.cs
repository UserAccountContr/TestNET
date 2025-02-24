namespace TestNET.Teacher.Service;

public partial class LogService : ObservableObject
{
    [ObservableProperty]
    string testLog;

    [ObservableProperty]
    bool submissionsViewable;
}
