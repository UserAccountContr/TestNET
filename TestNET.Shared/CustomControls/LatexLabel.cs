using WpfMath.Controls;

namespace TestNET.Shared.CustomControls;

[TemplatePart(Name = TEXT_DISPLAY_PART_NAME, Type = typeof(Label))]
public class LatexLabel : ContentControl
{
    private const string TEXT_DISPLAY_PART_NAME = "PART_TextDisplay";

    static LatexLabel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LatexLabel), new FrameworkPropertyMetadata(typeof(LatexLabel)));
    }

    public static readonly DependencyProperty IsMathProperty =
       DependencyProperty.Register("IsMath", typeof(bool), typeof(LatexLabel),
           new PropertyMetadata(false, OnIsMathPropertyChanged));

    public bool IsMath
    {
        get { return (bool)GetValue(IsMathProperty); }
        set { SetValue(IsMathProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
       DependencyProperty.Register("Text", typeof(string), typeof(LatexLabel),
           new PropertyMetadata("", OnTextPropertyChanged));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    private static void OnIsMathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is LatexLabel ll)
        {
            ll.OnIsMathPropertyChanged();
        }
    }
    private void OnIsMathPropertyChanged()
    {
        UpdateContent();
    }

    private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is LatexLabel ll)
        {
            ll.OnTextPropertyChanged();
        }
    }
    private void OnTextPropertyChanged()
    {
        UpdateContent();
    }

    private void UpdateContent()
    {
        if (IsMath)
        {
            var temp = new FormulaControl();
            temp.Formula = Text;
            Content = temp;
        }
        else
        {
            Content = Text;
        }
    }
}
