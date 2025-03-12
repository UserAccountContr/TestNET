namespace TestNET.Avalonia.Teacher.Service;

public interface INavigationService
{
    BaseViewModel CurrentViewModel { get; }

    void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
    void NavigateTo<TViewModel, TParameter>(TParameter t) where TViewModel : BaseViewModel;
}

public partial class NavigationService : ObservableObject, INavigationService
{
    [ObservableProperty]
    BaseViewModel currentViewModel;

    readonly Func<Type, BaseViewModel> viewModelFactory;
    readonly Func<Type, object, BaseViewModel> viewModelParameterFactory;

    public NavigationService(Func<Type, BaseViewModel> viewModelFactory, Func<Type, object, BaseViewModel> viewModelParameterFactory)
    {
        this.viewModelFactory = viewModelFactory;
        this.viewModelParameterFactory = viewModelParameterFactory;
    }

    public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
    {
        CurrentViewModel = viewModelFactory(typeof(TViewModel));
    }

    public void NavigateTo<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel
    {
        CurrentViewModel = viewModelParameterFactory(typeof(TViewModel), parameter);
    }
}
