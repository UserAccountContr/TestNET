using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string lastName;

    public string FullName { get => $"{FirstName} {LastName}"; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string code;

    public bool CanStart { get => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Code); }

    public HomeViewModel()
    {
    }
}
