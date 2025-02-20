namespace TestNET.Shared.CustomControls;

public class TestSubmPanel : Control
{
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
}
