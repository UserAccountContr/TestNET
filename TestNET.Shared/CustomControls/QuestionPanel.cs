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

    public static readonly DependencyProperty  MAXPointsProperty =
       DependencyProperty.Register("MAXPoints", typeof(float), typeof(QuestionPanel),
           new PropertyMetadata((float)0));

    public float MAXPoints
    {
        get { return (float)GetValue(MAXPointsProperty); }
        set { SetValue(MAXPointsProperty, value); }
    }

    public static readonly DependencyProperty DropdownContentProperty =
        DependencyProperty.Register("DropdownContent", typeof(object), typeof(QuestionPanel),
            new PropertyMetadata(null));

    public object DropdownContent
    {
        get { return GetValue(DropdownContentProperty); }
        set { SetValue(DropdownContentProperty, value); }
    }

    public static readonly DependencyProperty ShowDropdownProperty =
        DependencyProperty.Register("ShowDropdown", typeof(bool), typeof(QuestionPanel),
            new PropertyMetadata(false, OnPropertyChanged));

    public bool ShowDropdown
    {
        get { return (bool)GetValue(ShowDropdownProperty); }
        set { SetValue(ShowDropdownProperty, value); }
    }

    private static readonly DependencyPropertyKey ShowPointsPropertyKey =
       DependencyProperty.RegisterReadOnly("ShowPoints", typeof(bool), typeof(QuestionPanel),
           new PropertyMetadata(true));

    public static readonly DependencyProperty ShowPointsProperty = ShowPointsPropertyKey.DependencyProperty;

    public bool ShowPoints
    {
        get { return (bool)GetValue(ShowPointsProperty); }
    }

    static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is QuestionPanel q)
            q.OnPropertyChanged();
    }

    void OnPropertyChanged()
    {
        SetValue(ShowPointsPropertyKey, !ShowDropdown);
    }

    public override void OnApplyTemplate()
    {
        SetValue(ShowPointsPropertyKey, !ShowDropdown);

        base.OnApplyTemplate();
    }
}
