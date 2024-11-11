namespace TestNET.Teacher.Service;

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
    IServiceProvider serviceProvider;

    readonly Func<Type, BaseViewModel> viewModelFactory;

    public NavigationService(Func<Type, BaseViewModel> viewModelFactory, IServiceProvider serviceProvider)
    {
        this.viewModelFactory = viewModelFactory;
        this.serviceProvider = serviceProvider;
    }

    public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
    {
        CurrentViewModel = viewModelFactory(typeof(TViewModel));
    }

    public void NavigateTo<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel
    {
        CurrentViewModel = (TViewModel)ActivatorUtilities.CreateInstance(serviceProvider, typeof(TViewModel), parameter);
    }
}
