using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

public class QuestionViewPanel : TemplatedControl
{
    public static readonly StyledProperty<Question> QuestionProperty =
        AvaloniaProperty.Register<QuestionViewPanel, Question>(nameof(Question), null);

    public Question Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }


    public static readonly StyledProperty<int> QuestionIndexProperty =
        AvaloniaProperty.Register<QuestionViewPanel, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }
    
    
    public static readonly StyledProperty<bool> ShowAnswersProperty =
        AvaloniaProperty.Register<QuestionViewPanel, bool>(nameof(ShowAnswers), true);

    public bool ShowAnswers
    {
        get => GetValue(ShowAnswersProperty);
        set => SetValue(ShowAnswersProperty, value);
    }


    public static readonly StyledProperty<bool> EnableSolvingProperty =
        AvaloniaProperty.Register<QuestionViewPanel, bool>(nameof(EnableSolving), true);

    public bool EnableSolving
    {
        get => GetValue(EnableSolvingProperty);
        set => SetValue(EnableSolvingProperty, value);
    }
    
    

    public static readonly DirectProperty<QuestionViewPanel, ShortAnswerQuestion> QuestionSHProperty = 
        AvaloniaProperty.RegisterDirect<QuestionViewPanel, ShortAnswerQuestion>(
            nameof(QuestionSH), 
            o => o.QuestionSH);

    public ShortAnswerQuestion QuestionSH
    {
        get => Question is ShortAnswerQuestion saq ? saq : null;
    }

    public static readonly DirectProperty<QuestionViewPanel, MultipleChoiceQuestion> QuestionMCProperty = 
        AvaloniaProperty.RegisterDirect<QuestionViewPanel, MultipleChoiceQuestion>(
            nameof(QuestionMC), 
            o => o.QuestionMC);

    public MultipleChoiceQuestion QuestionMC
    {
        get => Question is MultipleChoiceQuestion mcq ? mcq : null;
    }

    public static readonly DirectProperty<QuestionViewPanel, MultipleChoiceManyQuestion> QuestionMCMProperty = 
        AvaloniaProperty.RegisterDirect<QuestionViewPanel, MultipleChoiceManyQuestion>(
            nameof(QuestionMCM), 
            o => o.QuestionMCM);

    public MultipleChoiceManyQuestion QuestionMCM
    {
        get => Question is MultipleChoiceManyQuestion mcmq ? mcmq : null;
    }

    public static readonly DirectProperty<QuestionViewPanel, string> QTypeProperty =
        AvaloniaProperty.RegisterDirect<QuestionViewPanel, string>(
            nameof(QType),
            o => o.QType);

    public string QType
    {
        get => Question.QType();
    }
}