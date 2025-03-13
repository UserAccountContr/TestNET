using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace TestNET.Avalonia.Shared.CustomControls;

public class QuestionPanel : ContentControl
{
    public static readonly StyledProperty<int> QuestionIndexProperty =
        AvaloniaProperty.Register<QuestionPanel, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }
    
    
    public static readonly StyledProperty<float> PointsProperty =
        AvaloniaProperty.Register<QuestionPanel, float>(nameof(Points), (float)0);

    public float Points
    {
        get => GetValue(PointsProperty);
        set => SetValue(PointsProperty, value);
    }


    public static readonly StyledProperty<float> MAXPointsProperty =
        AvaloniaProperty.Register<QuestionPanel, float>(nameof(MAXPoints), (float)0);

    public float MAXPoints
    {
        get => GetValue(MAXPointsProperty);
        set => SetValue(MAXPointsProperty, value);
    }
    
    
    public static readonly StyledProperty<object> DropdownContentProperty = 
        AvaloniaProperty.Register<QuestionPanel, object>(nameof(DropdownContent), null);

    public object DropdownContent
    {
        get => GetValue(DropdownContentProperty);
        set => SetValue(DropdownContentProperty, value);
    }
    
    public static readonly StyledProperty<bool> ShowDropdownProperty = 
        AvaloniaProperty.Register<QuestionPanel, bool>(nameof(ShowDropdown), false);

    public bool ShowDropdown
    {
        get => GetValue(ShowDropdownProperty);
        set => SetValue(ShowDropdownProperty, value);
    }
}