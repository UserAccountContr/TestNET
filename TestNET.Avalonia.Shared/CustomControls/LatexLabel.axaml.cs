using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

public class LatexLabel : TemplatedControl
{
    public static readonly StyledProperty<bool> IsMathProperty = 
        AvaloniaProperty.Register<LatexLabel, bool>(nameof(IsMath), false);

    public bool IsMath 
    {
        get => GetValue(IsMathProperty);
        set => SetValue(IsMathProperty, value);
    }
    
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<LatexLabel, string>(nameof(Text), string.Empty);

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}