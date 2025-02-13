namespace TestNET.Shared.CustomControls;

public class LatexTextBox : Control
{
    static LatexTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LatexTextBox), new FrameworkPropertyMetadata(typeof(LatexTextBox)));
    }

    public static readonly DependencyProperty IsMathProperty =
       DependencyProperty.Register("IsMath", typeof(bool), typeof(LatexTextBox),
           new PropertyMetadata(false));

    public bool IsMath
    {
        get { return (bool)GetValue(IsMathProperty); }
        set { SetValue(IsMathProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
       DependencyProperty.Register("Text", typeof(string), typeof(LatexTextBox),
           new PropertyMetadata(""));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
}
