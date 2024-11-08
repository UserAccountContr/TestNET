namespace TestNET.Student.ViewModel;

public partial class TestOverviewViewModel : BaseViewModel
{
    [ObservableProperty]
    Test test;

    public TestOverviewViewModel(Test test) 
    { 
        Test = test;
    }
}
