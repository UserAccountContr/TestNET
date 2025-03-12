using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using TestNET.Avalonia.Teacher.ViewModels;
using TestNET.Avalonia.Teacher.Views;
using TestNET.Avalonia.Teacher.Service;

namespace TestNET.Avalonia.Teacher;

public partial class App : Application
{
    private IServiceProvider serviceProvider;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        serviceProvider = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //desktop.MainWindow = new MainWindow
            //{
            //    DataContext = new MainViewModel()
            //};

            desktop.MainWindow = serviceProvider.GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            //singleViewPlatform.MainView = new MainView
            //{
            //    DataContext = new MainViewModel()
            //};

            singleViewPlatform.MainView = serviceProvider.GetRequiredService<MainView>();
            singleViewPlatform.MainView.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddSingleton<TestService>();

        services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));
        services.AddSingleton<Func<Type, object, BaseViewModel>>(serviceProvider => (viewModelType, test) => (BaseViewModel)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType, test));

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainView>();
        services.AddSingleton<HomeView>();

        services.AddSingleton<MainViewModel>();
        //services.AddSingleton<WindowViewModel>();
        services.AddSingleton<HomeViewModel>();

        services.AddSingleton<LogService>();
    }
}
