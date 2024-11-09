namespace TestNET.Student.ViewModel;

public partial class TestSolvingViewModel : BaseViewModel
{
    public TestSolvingViewModel(Test test)
    {
        Test = test;
    }

    [ObservableProperty]
    Test test;

    [RelayCommand]
    void Submit() => MessageBox.Show("yay :)");
}
