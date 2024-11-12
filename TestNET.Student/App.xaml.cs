using TestNET.Student.Service;

namespace TestNET.Student;

public partial class App : Application
{
    private IServiceProvider serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        serviceProvider = serviceCollection.BuildServiceProvider();
        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<TestService>();
        
        services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));
        services.AddSingleton<Func<Type, object, BaseViewModel>>(serviceProvider => (viewModelType, test) => (BaseViewModel)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType, test));

        services.AddSingleton<MainWindow>();
        services.AddSingleton<HomeView>();

        services.AddSingleton<WindowViewModel>();
        services.AddSingleton<HomeViewModel>();
    }

}
