using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    INavigationService navigation;
    TestService testService;

    public HomeViewModel(INavigationService navigation, TestService testService)
    {
        Navigation = navigation;
        this.testService = testService;

        RevMode = false;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    [NotifyPropertyChangedFor(nameof(CanStartReview))]
    string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    [NotifyPropertyChangedFor(nameof(CanStartReview))]
    string lastName;

    public string FullName { get => $"{FirstName} {LastName}"; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    [NotifyPropertyChangedFor(nameof(CanStartReview))]
    string code;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    [NotifyPropertyChangedFor(nameof(CanStartReview))]
    string revPass;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NotRevMode))]
    bool revMode;

    public bool NotRevMode => !RevMode;

    public bool CanStart { get => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Code) && IsNotGettingTest; }

    public bool CanStartReview => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Code) && IsNotGettingTest && !string.IsNullOrEmpty(RevPass);

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotGettingTest))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    [NotifyPropertyChangedFor(nameof(CanStartReview))]
    bool isGettingTest;

    public bool IsNotGettingTest { get => !IsGettingTest; }

    [RelayCommand]
    async Task GoToTestOverview(object[] parameters)
    {
        IsGettingTest = true;
        Test test = await Task.Run(() => testService.GetTest(parameters[0].ToString(), parameters[1].ToString()));
        if (test != null)
            Navigation.NavigateTo<TestOverviewViewModel, Test>(test);
        IsGettingTest = false;
    }

    [RelayCommand]
    async Task GoToSubmReview(object[] parameters)
    {
        IsGettingTest = true;
        Submission subm = await Task.Run(() => testService.GetSubm(parameters[0].ToString(), parameters[1].ToString(), parameters[2].ToString()));
        if (subm != null)
            Navigation.NavigateTo<SubmissionReviewViewModel, Submission>(subm);
        IsGettingTest = false;
    }

    [RelayCommand]
    void EnableRevMode() => RevMode = true;

    [RelayCommand]
    void DisableRevMode() => RevMode = false;
}
