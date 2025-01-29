namespace TestNET.Shared.CustomControls;

public class QuestionPanel : ContentControl
{
    static QuestionPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionPanel), new FrameworkPropertyMetadata(typeof(QuestionPanel)));
    }

    public static readonly DependencyProperty QuestionIndexProperty =
       DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionPanel),
           new PropertyMetadata(0));

    public int QuestionIndex
    {
        get { return (int)GetValue(QuestionIndexProperty); }
        set { SetValue(QuestionIndexProperty, value); }
    }

    public static readonly DependencyProperty PointsProperty =
       DependencyProperty.Register("Points", typeof(float), typeof(QuestionPanel),
           new PropertyMetadata((float)0));

    public float Points
    {
        get { return (float)GetValue(PointsProperty); }
        set { SetValue(PointsProperty, value); }
    }
}
