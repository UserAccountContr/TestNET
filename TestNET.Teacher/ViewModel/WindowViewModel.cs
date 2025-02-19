using TestNET.Teacher.Service;

namespace TestNET.Teacher.ViewModel;

public partial class WindowViewModel : BaseViewModel
{
    public WindowViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
        GoToHomeView();

        if (Navigation.CurrentViewModel is HomeViewModel hvm)
        {
            hvm.LoadTestCommand.Execute(null);
        }
    }

    [ObservableProperty]
    INavigationService navigation;

    [RelayCommand]
    void OpenTestView(object test) => Navigation.NavigateTo<TestViewModel, Test>(test as Test);

    [RelayCommand]
    void OpenEditTestView(object test) => Navigation.NavigateTo<EditTestViewModel, Test>(test as Test);

    [RelayCommand]
    void GoToHomeView() => Navigation.NavigateTo<HomeViewModel>();

    public void OnWindowClosing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        if (Navigation.CurrentViewModel is EditTestViewModel cvm)
        {
            bool savesuccess = true;
            if (cvm.IsDirty)
            {
                var result = MessageBox.Show("You have unsaved changes!", Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        cvm.SaveChanges(out savesuccess);
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        return;
                }
            }

            if (!savesuccess)
            {
                MessageBox.Show("Save failed!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel=true;
                return;
            }
        }
        if (Navigation.CurrentViewModel is not HomeViewModel)
        {
            Navigation.NavigateTo<HomeViewModel>();
        }
        if (Navigation.CurrentViewModel is HomeViewModel hmv)
        {
            hmv.SaveTestCommand.Execute(null);
        }
    }
}
