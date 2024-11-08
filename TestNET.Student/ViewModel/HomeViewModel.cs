using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    //[ObservableProperty]
    //Test test;
    //
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    string lastName;

    public string FullName { get => $"{FirstName + LastName}"; }

    [ObservableProperty]
    string code;

    //TestService service;

    public HomeViewModel()
    {
        //service = new TestService();
    }

    //[RelayCommand]
    //async Task<Test> GetTest() => await service.GetTest();
}
