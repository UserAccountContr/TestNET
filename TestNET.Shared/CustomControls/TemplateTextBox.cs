namespace TestNET.Shared.CustomControls;

public class TemplateTextBox : TextBox
{
    static TemplateTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TemplateTextBox), new FrameworkPropertyMetadata(typeof(TemplateTextBox)));
    }

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register("Placeholder", typeof(string), typeof(TemplateTextBox),
            new PropertyMetadata("Enter text here..."));

    public string Placeholder
    {
        get { return (string)GetValue(TemplateProperty); }
        set { SetValue(TemplateProperty, value); }
    }
}
