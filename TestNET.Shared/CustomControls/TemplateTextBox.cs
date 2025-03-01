namespace TestNET.Shared.CustomControls;

public class TemplateTextBox : TextBox
{
    static TemplateTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TemplateTextBox), new FrameworkPropertyMetadata(typeof(TemplateTextBox)));
    }

    public override void OnApplyTemplate()
    {
        this.SetResourceReference(PlaceholderProperty, "enterText");
        base.OnApplyTemplate();
    }

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register("Placeholder", typeof(string), typeof(TemplateTextBox),
            new PropertyMetadata(Application.Current.FindResource("enterText")));

    public string Placeholder
    {
        get { return (string)GetValue(TemplateProperty); }
        set { SetValue(TemplateProperty, value); }
    }
}
