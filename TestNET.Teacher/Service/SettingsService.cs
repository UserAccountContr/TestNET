namespace TestNET.Teacher.Service;

public interface ISettingsService
{
    public void ChangeTheme(string style);
    public void ChangeLanguage(string language);
}

public class SettingsService : ISettingsService
{
    public void ChangeTheme(string style)
    {
        Change("Styles", style);
    }

    public void ChangeLanguage(string language)
    {
        Change("StringResources", language);
    }

    private void Change(string property, string value)
    {
        foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
        {
            if (dictionary.Source is not null && dictionary.Source.ToString().Contains($"{property}"))
            {
                Application.Current.Resources.MergedDictionaries.Remove(dictionary);
                break;
            }
        }

        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri($"pack://application:,,,/TestNET.Shared;component/Resources/{property}.{value}.xaml", UriKind.Absolute) });
    }
}
