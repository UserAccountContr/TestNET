using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

[TemplatePart(Name = PART_POPUP_NAME, Type = typeof(Popup))]
[TemplatePart(Name = PART_TOGGLE_NAME, Type = typeof(CheckBox))]
public class DropdownMenu : ContentControl
{
    private const string PART_POPUP_NAME = "PART_Popup";
    private const string PART_TOGGLE_NAME = "PART_Toggle";

    private Popup? _popup;
    private CheckBox? _toggle;

    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<DropdownMenu, bool>(nameof(IsOpen), false);

    public bool IsOpen
    {
        get => GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    //static DropdownMenu()
    //{
    //    DefaultStyleKeyProperty.OverrideMetadata(typeof(DropdownMenu), new FrameworkPropertyMetadata(typeof(DropdownMenu)));
    //}

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        // _popup = Template.FindName(PART_POPUP_NAME, this) as Popup;
        _popup = e.NameScope.Find<Popup>(PART_POPUP_NAME);
        if (_popup != null)
        {
            _popup.Closed += Popup_Closed;
            _popup.PointerReleased += (s, e2) => IsOpen = false;
        }

        _toggle = e.NameScope.Find<CheckBox>(PART_TOGGLE_NAME);

        base.OnApplyTemplate(e);
    }

    private void Popup_Closed(object sender, EventArgs e)
    {
        if (_toggle is not null && !_toggle.IsPointerOver)
        {
            IsOpen = false;
        }
    }
}