namespace TestNET.Shared.CustomControls;

[TemplatePart(Name = PlusBtnName, Type = typeof(Button))]
[TemplatePart(Name = MinusBtnName, Type = typeof(Button))]
[TemplatePart(Name = FullBtnName, Type = typeof(Button))]
[TemplatePart(Name = HalfBtnName, Type = typeof(Button))]
[TemplatePart(Name = ZeroBtnName, Type = typeof(Button))]
public class QuestionSubmPanelSH : Control
{
    Button? _plusbtn;
    Button? _minusbtn;
    Button? _fullbtn;
    Button? _halfbtn;
    Button? _zerobtn;

    private const string PlusBtnName = "plus25";
    private const string MinusBtnName = "minus25";
    private const string FullBtnName = "fullpts";
    private const string HalfBtnName = "halfpts";
    private const string ZeroBtnName = "zeropts";

    static QuestionSubmPanelSH()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelSH), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelSH)));
    }

    public static readonly DependencyProperty QuestionProperty =
       DependencyProperty.Register("Question", typeof(ShortAnswerQuestion), typeof(QuestionSubmPanelSH),
           new PropertyMetadata(null));

    public ShortAnswerQuestion Question
    {
        get { return (ShortAnswerQuestion)GetValue(QuestionProperty); }
        set { SetValue(QuestionProperty, value); }
    }

    public static readonly DependencyProperty TestProperty =
       DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelSH),
           new PropertyMetadata(null));

    public Test Test
    {
        get { return (Test)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }

    public static readonly DependencyProperty QuestionIndexProperty =
       DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionSubmPanelSH),
           new PropertyMetadata(0));

    public int QuestionIndex
    {
        get { return (int)GetValue(QuestionIndexProperty); }
        set { SetValue(QuestionIndexProperty, value); }
    }

    public static readonly DependencyProperty IsTeacherProperty =
        DependencyProperty.Register("IsTeacher", typeof(bool), typeof(QuestionSubmPanelSH),
            new PropertyMetadata(false));

    public bool IsTeacher
    {
        get { return (bool)GetValue(IsTeacherProperty); }
        set { SetValue(IsTeacherProperty, value); }
    }

    public override void OnApplyTemplate()
    {
        _plusbtn = (Button)Template.FindName(PlusBtnName, this);
        if (_plusbtn is not null)
            _plusbtn.Click += (s, e) =>
            {
                Question.Points = Math.Min(maxpoints, Question.Points + 0.25f);
            };

        _minusbtn = (Button)Template.FindName(MinusBtnName, this);
        if (_minusbtn is not null)
            _minusbtn.Click += (s, e) =>
            {
                Question.Points = Math.Max(0, Question.Points -= 0.25f);
            };

        _fullbtn = (Button)Template.FindName(FullBtnName, this);
        if (_fullbtn is not null)
            _fullbtn.Click += (s, e) => { Question.Points = maxpoints; };

        _halfbtn = (Button)Template.FindName(HalfBtnName, this);
        if (_halfbtn is not null)
            _halfbtn.Click += (s, e) => { Question.Points = maxpoints / 2; };

        _zerobtn = (Button)Template.FindName(ZeroBtnName, this);
        if (_zerobtn is not null)
            _zerobtn.Click += (s, e) => { Question.Points = 0; };
        base.OnApplyTemplate();
    }


    float maxpoints => Test.Questions.Where(x => x.UniqueId == Question.UniqueId).FirstOrDefault()?.Points ?? 0;
}

public class QuestionSubmPanelMC : Control
{
    static QuestionSubmPanelMC()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelMC), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelMC)));
    }

    public static readonly DependencyProperty QuestionProperty =
       DependencyProperty.Register("Question", typeof(MultipleChoiceQuestion), typeof(QuestionSubmPanelMC),
           new PropertyMetadata(null));

    public MultipleChoiceQuestion Question
    {
        get { return (MultipleChoiceQuestion)GetValue(QuestionProperty); }
        set { SetValue(QuestionProperty, value); }
    }

    public static readonly DependencyProperty TestProperty =
       DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelMC),
           new PropertyMetadata(null));

    public Test Test
    {
        get { return (Test)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }

    public static readonly DependencyProperty QuestionIndexProperty =
       DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionSubmPanelMC),
           new PropertyMetadata(0));

    public int QuestionIndex
    {
        get { return (int)GetValue(QuestionIndexProperty); }
        set { SetValue(QuestionIndexProperty, value); }
    }
}

public class QuestionSubmPanelMCM : Control
{
    static QuestionSubmPanelMCM()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelMCM), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelMCM)));
    }

    public static readonly DependencyProperty QuestionProperty =
       DependencyProperty.Register("Question", typeof(MultipleChoiceManyQuestion), typeof(QuestionSubmPanelMCM),
           new PropertyMetadata(null));

    public MultipleChoiceManyQuestion Question
    {
        get { return (MultipleChoiceManyQuestion)GetValue(QuestionProperty); }
        set { SetValue(QuestionProperty, value); }
    }

    public static readonly DependencyProperty TestProperty =
       DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelMCM),
           new PropertyMetadata(null));

    public Test Test
    {
        get { return (Test)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }

    public static readonly DependencyProperty QuestionIndexProperty =
       DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionSubmPanelMCM),
           new PropertyMetadata(0));

    public int QuestionIndex
    {
        get { return (int)GetValue(QuestionIndexProperty); }
        set { SetValue(QuestionIndexProperty, value); }
    }
}