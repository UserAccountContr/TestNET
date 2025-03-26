using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

[TemplatePart(Name = RGR_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Accept_BTN_NAME, Type = typeof(Button))]
public class TestSubmPanel : TemplatedControl
{
    private const string RGR_BTN_NAME = "RGR_BTN";
    private const string Accept_BTN_NAME = "Accept_BTN";
    private Button? _rgrbtn;
    private Button? _acceptbtn;

    public static readonly StyledProperty<Submission> SubmissionProperty = AvaloniaProperty.Register<TestSubmPanel, Submission>(
        nameof(Submission), null);

    public Submission Submission
    {
        get => GetValue(SubmissionProperty);
        set => SetValue(SubmissionProperty, value);
    }


    public static readonly StyledProperty<bool> IsTeacherProperty = AvaloniaProperty.Register<TestSubmPanel, bool>(
        nameof(IsTeacher), false);

    public bool IsTeacher
    {
        get => GetValue(IsTeacherProperty);
        set => SetValue(IsTeacherProperty, value);
    }


    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        _rgrbtn = e.NameScope.Find<Button>(RGR_BTN_NAME);
        if (_rgrbtn != null)
        {
            _rgrbtn.Click += (s, re) =>
            {
                Submission.Grade();
            };
        }
        
        _acceptbtn = e.NameScope.Find<Button>(Accept_BTN_NAME);
        if (_acceptbtn != null)
        {
            _acceptbtn.Click += (s, re) =>
            {
                Submission.RequiresAttention = false;
            };
        }
        
        base.OnApplyTemplate(e);
    }
}