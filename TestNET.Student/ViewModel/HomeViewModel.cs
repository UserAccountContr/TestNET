using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    Test test;

    TestService service;

    public HomeViewModel()
    {
        service = new TestService();
    }

    [RelayCommand]
    async void GetTest()
    {

        this.Test = await service.GetTest();
    }
}
