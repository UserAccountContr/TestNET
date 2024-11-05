namespace TestNET.Teacher.ViewModel;

public partial class EditTestViewModel : BaseViewModel
{
    [ObservableProperty]
    Test test;

    public EditTestViewModel(Test test)
    {
        Test = test;
    }

    [RelayCommand]
    void AddQuestion() => Test.AddQuestion();
}
