using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace TestNET.Avalonia.Shared;

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

    private static readonly StyledProperty<Question> QuestionProperty =
        AvaloniaProperty.Register<QuestionSubmPanel, Question>(nameof(Question), null);

    public Question Question
    {
        get => GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }


}