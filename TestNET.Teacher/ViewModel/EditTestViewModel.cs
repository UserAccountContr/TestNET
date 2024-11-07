namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    [ObservableProperty]
    Test test;

    Test original;

    public EditTestViewModel(Test test)
    {
        Test = test;
        original = test.DeepCopy();
    }

    [RelayCommand]
    void AddQuestion() => Test.AddQuestion();

    [RelayCommand]
    void Cancel() => Test = original.DeepCopy();
}
