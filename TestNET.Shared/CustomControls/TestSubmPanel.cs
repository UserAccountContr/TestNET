namespace TestNET.Shared.CustomControls;

[TemplatePart(Name = RGR_BTN_NAME, Type = typeof(Button))]
public class TestSubmPanel : Control
{
    private const string RGR_BTN_NAME = "RGR_BTN";
    private Button _rgrbtn;

    static TestSubmPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TestSubmPanel), new FrameworkPropertyMetadata(typeof(TestSubmPanel)));
    }

    public static readonly DependencyProperty SubmissionProperty =
       DependencyProperty.Register("Submission", typeof(Submission), typeof(TestSubmPanel),
           new PropertyMetadata(null));

    public Submission Submission
    {
        get { return (Submission)GetValue(SubmissionProperty); }
        set { SetValue(SubmissionProperty, value); }
    }

    public override void OnApplyTemplate()
    {
        _rgrbtn = Template.FindName(RGR_BTN_NAME, this) as Button;
        if (_rgrbtn != null)
        {
            _rgrbtn.Click += (s, e) =>
            {
                Submission.Points = Submission.Grade();
            };
        }
        base.OnApplyTemplate();
    }
}
