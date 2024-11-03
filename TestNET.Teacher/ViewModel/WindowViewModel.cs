namespace TestNET.Teacher.ViewModel;

public partial class WindowViewModel: BaseViewModel
{
    public WindowViewModel()
    {
        PageViewModels.Add(new TestViewModel());

        currentPageViewModel = PageViewModels[0];
    }

    ObservableCollection<ObservableObject> PageViewModels = new();

    [ObservableProperty]
    ObservableObject currentPageViewModel;


}
