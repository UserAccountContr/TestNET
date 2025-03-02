namespace TestNET.Shared.CustomControls;

public class TemplateTextBox : TextBox
{
    static TemplateTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TemplateTextBox), new FrameworkPropertyMetadata(typeof(TemplateTextBox)));
    }

    public override void OnApplyTemplate()
    {
        if (string.IsNullOrEmpty(Placeholder))
            SetResourceReference(PlaceholderProperty, "enterText");
        base.OnApplyTemplate();
    }

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register("Placeholder", typeof(string), typeof(TemplateTextBox),
            new PropertyMetadata(null));

    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }
}
