namespace TestNET.Teacher.View;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if((bool)(sender as RadioButton).IsChecked)
        ChangeLanguage((sender as RadioButton).Tag.ToString());
    }

    private void ChangeLanguage(string language)
    {
        foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
        {
            if (dictionary.Source != null && dictionary.Source.ToString().Contains($"StringResources"))
            {
                Application.Current.Resources.MergedDictionaries.Remove(dictionary);
                break; // The language is already set, so do nothing
            }
        }

        // Add the appropriate dictionary for the selected language
        switch (language)
        {
            case "en":
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/TestNET.Shared;component/Resources/StringResources.en.xaml", UriKind.Absolute) });
                break;
            case "bg":
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/TestNET.Shared;component/Resources/StringResources.bg.xaml", UriKind.Absolute) });
                break;
                // Add more languages if needed
        }
    }
}