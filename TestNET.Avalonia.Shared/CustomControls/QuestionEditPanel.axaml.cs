using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared.CustomControls;

public class QuestionEditPanel : TemplatedControl
{
    public static readonly StyledProperty<Question> QuestionProperty = 
        AvaloniaProperty.Register<QuestionEditPanel, Question>(nameof(Question), null);

    public Question Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }
    
    
    public static readonly StyledProperty<bool> IsInEditModeProperty = 
        AvaloniaProperty.Register<QuestionEditPanel, bool>(nameof(IsInEditMode), false);

    public bool IsInEditMode
    {
        get => GetValue(IsInEditModeProperty);
        set => SetValue(IsInEditModeProperty, value);
    }
    
    
    public static readonly StyledProperty<int> QuestionIndexProperty = 
        AvaloniaProperty.Register<QuestionEditPanel, int>(nameof(QuestionIndex), 0);

    public int QuestionIndex
    {
        get => GetValue(QuestionIndexProperty);
        set => SetValue(QuestionIndexProperty, value);
    }
    
    
    
    public static readonly DirectProperty<QuestionEditPanel, ShortAnswerQuestion> QuestionSHProperty = 
        AvaloniaProperty.RegisterDirect<QuestionEditPanel, ShortAnswerQuestion>(
            nameof(QuestionSH), 
            o => o.QuestionSH);

    public ShortAnswerQuestion QuestionSH
    {
        get => Question is ShortAnswerQuestion saq ? saq : null;
    }

    public static readonly DirectProperty<QuestionEditPanel, MultipleChoiceQuestion> QuestionMCProperty = 
        AvaloniaProperty.RegisterDirect<QuestionEditPanel, MultipleChoiceQuestion>(
            nameof(QuestionMC), 
            o => o.QuestionMC);

    public MultipleChoiceQuestion QuestionMC
    {
        get => Question is MultipleChoiceQuestion mcq ? mcq : null;
    }

    public static readonly DirectProperty<QuestionEditPanel, MultipleChoiceManyQuestion> QuestionMCMProperty = 
        AvaloniaProperty.RegisterDirect<QuestionEditPanel, MultipleChoiceManyQuestion>(
            nameof(QuestionMCM), 
            o => o.QuestionMCM);

    public MultipleChoiceManyQuestion QuestionMCM
    {
        get => Question is MultipleChoiceManyQuestion mcmq ? mcmq : null;
    }

    public static readonly DirectProperty<QuestionEditPanel, string> QTypeProperty =
        AvaloniaProperty.RegisterDirect<QuestionEditPanel, string>(
            nameof(QType),
            o => o.QType);

    public string QType
    {
        get => Question.QType();
    }
}