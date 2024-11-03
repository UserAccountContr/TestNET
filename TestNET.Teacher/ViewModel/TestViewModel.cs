namespace TestNET.Teacher.ViewModel;

public partial class TestViewModel : BaseViewModel
{
    public TestViewModel(Test test)
    {
        this.test = test;
    }

    [ObservableProperty]
    Test test;


}
