using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

[TemplatePart(Name = PlusBtnName, Type = typeof(Button))]
[TemplatePart(Name = MinusBtnName, Type = typeof(Button))]
[TemplatePart(Name = FullBtnName, Type = typeof(Button))]
[TemplatePart(Name = HalfBtnName, Type = typeof(Button))]
[TemplatePart(Name = ZeroBtnName, Type = typeof(Button))]
public class QuestionSubmPanelSH : TemplatedControl
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

    public static readonly StyledProperty<ShortAnswerQuestion> QuestionProperty =
        AvaloniaProperty.Register<QuestionSubmPanelSH, ShortAnswerQuestion>(nameof(Question), null);

    public ShortAnswerQuestion Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }


    public static readonly StyledProperty<Test> TestProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelSH, Test>(nameof(Test), null);

    public Test Test
    {
        get => GetValue(TestProperty);
        set => SetValue(TestProperty, value);
    }


    public static readonly StyledProperty<int> QuestionIndexProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelSH, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }


    public static readonly StyledProperty<bool> IsTeacherProperty = AvaloniaProperty.Register<QuestionSubmPanelSH, bool>(
        nameof(IsTeacher), false);

    public bool IsTeacher
    {
        get => GetValue(IsTeacherProperty);
        set => SetValue(IsTeacherProperty, value);
    }
    
    
    float maxpoints => Test.Questions.Where(x => x.UniqueId == Question.UniqueId).FirstOrDefault()?.Points ?? 0;


    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        _plusbtn = e.NameScope.Find<Button>(PlusBtnName);
        if (_plusbtn is not null)
            _plusbtn.Click += (s, re) =>
            {
                Question.Points = Math.Min(maxpoints, Question.Points + 0.25f);
            };
        
        _minusbtn = e.NameScope.Find<Button>(MinusBtnName);
        if (_minusbtn is not null)
            _minusbtn.Click += (s, re) =>
            {
                Question.Points = Math.Max(0, Question.Points -= 0.25f);
            };

        _fullbtn = e.NameScope.Find<Button>(FullBtnName);
        if (_fullbtn is not null)
            _fullbtn.Click += (s, re) => { Question.Points = maxpoints; };

        _halfbtn = e.NameScope.Find<Button>(HalfBtnName);
        if (_halfbtn is not null)
            _halfbtn.Click += (s, re) => { Question.Points = maxpoints / 2; };

        _zerobtn = e.NameScope.Find<Button>(ZeroBtnName);
        if (_zerobtn is not null)
            _zerobtn.Click += (s, re) => { Question.Points = 0; };
        
        base.OnApplyTemplate(e);
    }
}

public class QuestionSubmPanelMC : TemplatedControl
{
    public static readonly StyledProperty<MultipleChoiceQuestion> QuestionProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMC, MultipleChoiceQuestion>(nameof(Question), null);

    public MultipleChoiceQuestion Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }


    public static readonly StyledProperty<Test> TestProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMC, Test>(nameof(Test), null);

    public Test Test
    {
        get => GetValue(TestProperty);
        set => SetValue(TestProperty, value);
    }


    public static readonly StyledProperty<int> QuestionIndexProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMC, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }
}

public class QuestionSubmPanelMCM : TemplatedControl
{
    public static readonly StyledProperty<MultipleChoiceManyQuestion> QuestionProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMCM, MultipleChoiceManyQuestion>(nameof(Question), null);

    public MultipleChoiceManyQuestion Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }


    public static readonly StyledProperty<Test> TestProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMCM, Test>(nameof(Test), null);

    public Test Test
    {
        get => GetValue(TestProperty);
        set => SetValue(TestProperty, value);
    }


    public static readonly StyledProperty<int> QuestionIndexProperty = 
        AvaloniaProperty.Register<QuestionSubmPanelMCM, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }
}