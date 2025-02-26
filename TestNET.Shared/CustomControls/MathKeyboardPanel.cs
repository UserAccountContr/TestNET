using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MathKeyboardEngine;
using MathKeyboardEngine.__Helpers;

namespace TestNET.Shared.CustomControls;


[TemplatePart(Name = PART_GRID_NAME, Type = typeof(Grid))]
[TemplatePart(Name = PART_TOGGLE_NAME, Type = typeof(CheckBox))]
[TemplatePart(Name = PART_SAVEBTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = PART_CANCELBTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = TEXT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NEWLINE_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = SQRT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NTHRT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = DEG_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = INF_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = SIN_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = COS_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = CUP_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = CAP_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = TG_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = COTG_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = LIM_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = LIMX_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = veca_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = vecb_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = vecc_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = vec_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = IN_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = sys_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = cases_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMGT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMGTE_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMLT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMLTE_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMDOT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMPLUS_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMMINUS_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMTIMES_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMDIVIDE_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUMEQ_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM0_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM1_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM2_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM3_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM4_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM5_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM6_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM7_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM8_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NUM9_BTN_NAME, Type = typeof(Button))]
public class MathKeyboardPanel : Control
{
    LatexConfiguration latexConfiguration = new LatexConfiguration();
    KeyboardMemory keyboardMemory = new KeyboardMemory();

    private const string PART_GRID_NAME = "PART_GRID";
    private const string PART_TOGGLE_NAME = "PART_Toggle";
    private const string PART_SAVEBTN_NAME = "SAVE_BTN";
    private const string PART_CANCELBTN_NAME = "CANCEL_BTN";
    private const string TEXT_BTN_NAME = "TEXT_BTN";
    private const string NEWLINE_BTN_NAME = "NEWLINE_BTN";
    private const string SQRT_BTN_NAME = "SQRT_BTN";
    private const string NTHRT_BTN_NAME = "NTHRT_BTN";
    private const string FRAC_BTN_NAME = "FRAC_BTN";
    private const string DEG_BTN_NAME = "DEG_BTN";
    private const string INF_BTN_NAME = "INF_BTN";
    private const string SIN_BTN_NAME = "SIN_BTN";
    private const string COS_BTN_NAME = "COS_BTN";
    private const string CUP_BTN_NAME = "CUP_BTN";
    private const string CAP_BTN_NAME = "CAP_BTN";
    private const string TG_BTN_NAME = "TG_BTN";
    private const string COTG_BTN_NAME = "COTG_BTN";
    private const string LIM_BTN_NAME = "LIM_BTN";
    private const string LIMX_BTN_NAME = "LIMX_BTN";
    private const string veca_BTN_NAME = "veca_BTN";
    private const string vecb_BTN_NAME = "vecb_BTN";
    private const string vecc_BTN_NAME = "vecc_BTN";
    private const string vec_BTN_NAME = "vec_BTN";
    private const string pi_BTN_NAME = "pi_BTN";
    private const string IN_BTN_NAME = "IN_BTN";
    private const string sys_BTN_NAME = "sys_BTN";
    private const string cases_BTN_NAME = "cases_BTN";
    private const string NUMGT_BTN_NAME = "NUMGT_BTN";
    private const string NUMGTE_BTN_NAME = "NUMGTE_BTN";
    private const string NUMLT_BTN_NAME = "NUMLT_BTN";
    private const string NUMLTE_BTN_NAME = "NUMLTE_BTN";
    private const string NUMDOT_BTN_NAME = "NUMDOT_BTN";
    private const string NUMPLUS_BTN_NAME = "NUMPLUS_BTN";
    private const string NUMMINUS_BTN_NAME = "NUMMINUS_BTN";
    private const string NUMTIMES_BTN_NAME = "NUMTIMES_BTN";
    private const string NUMDIVIDE_BTN_NAME = "NUMDIVIDE_BTN";
    private const string NUMEQ_BTN_NAME = "NUMEQ_BTN";
    private const string NUM0_BTN_NAME = "NUM0_BTN";
    private const string NUM1_BTN_NAME = "NUM1_BTN";
    private const string NUM2_BTN_NAME = "NUM2_BTN";
    private const string NUM3_BTN_NAME = "NUM3_BTN";
    private const string NUM4_BTN_NAME = "NUM4_BTN";
    private const string NUM5_BTN_NAME = "NUM5_BTN";
    private const string NUM6_BTN_NAME = "NUM6_BTN";
    private const string NUM7_BTN_NAME = "NUM7_BTN";
    private const string NUM8_BTN_NAME = "NUM8_BTN";
    private const string NUM9_BTN_NAME = "NUM9_BTN";

    private Grid _grid;
    private CheckBox _toggle;
    private Button _savebtn;
    private Button _cancelbtn;
    private Button _textbtn;
    private Button _nlbtn;
    private Button _sqrtbtn;
    private Button _nthrtbtn;
    private Button _fracbtn;
    private Button _degbtn;
    private Button _infbtn;
    private Button _sinbtn;
    private Button _cosbtn;
    private Button _cupbtn;
    private Button _capbtn;
    private Button _tgbtn;
    private Button _cotgbtn;
    private Button _limbtn;
    private Button _limxbtn;
    private Button _vecabtn;
    private Button _vecbbtn;
    private Button _veccbtn;
    private Button _vecbtn;
    private Button _pibtn;
    private Button _inbtn;
    private Button _sysbtn;
    private Button _casesbtn;
    private Button _num0btn;
    private Button _num1btn;
    private Button _num2btn;
    private Button _num3btn;
    private Button _num4btn;
    private Button _num5btn;
    private Button _num6btn;
    private Button _num7btn;
    private Button _num8btn;
    private Button _num9btn;
    private Button _numgtbtn;
    private Button _numgtebtn;
    private Button _numltbtn;
    private Button _numltebtn;
    private Button _numdotbtn;
    private Button _numplusbtn;
    private Button _numminusbtn;
    private Button _numtimesbtn;
    private Button _numdividebtn;
    private Button _numeqbtn;

    #region Properties

    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MathKeyboardPanel q)
        {
            q.OnPropertyChanged();
        }
    }

    private void OnPropertyChanged()
    {
        if (IsOpen == true && _grid is not null) 
            Keyboard.Focus(_grid);
    }

    public static readonly DependencyProperty IsOpenProperty =
        DependencyProperty.Register("IsOpen", typeof(bool), typeof(MathKeyboardPanel),
            new PropertyMetadata(false, OnPropertyChanged));

    public bool IsOpen
    {
        get { return (bool)GetValue(IsOpenProperty); }
        set { SetValue(IsOpenProperty, value); }
    }

    public static readonly DependencyProperty TBTextProperty =
        DependencyProperty.Register("TBText", typeof(string), typeof(MathKeyboardPanel),
            new PropertyMetadata(string.Empty, OnTBTextEdit));

    private static void OnTBTextEdit(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue) return;
        if (d is MathKeyboardPanel q)
        {
            q.TBNewText();
        }
    }

    private async void TBNewText()
    {
        try
        {
            var parsedNodes = Parse.Latex(TBText).SyntaxTreeRoot.Nodes;
            keyboardMemory = new KeyboardMemory
            {

            };
            keyboardMemory.Insert(parsedNodes);

            await DisplayResultAsync();
        }
        catch {}
    }

    public string TBText
    {
        get { return (string)GetValue(TBTextProperty); }
        set { SetValue(TBTextProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(MathKeyboardPanel),
            new PropertyMetadata(string.Empty, OnTextEdit));

    private static void OnTextEdit(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue) return;
        if (d is MathKeyboardPanel q)
        {
            q.NewText();
        }
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    private static readonly DependencyPropertyKey TempTextPropertyKey =
        DependencyProperty.RegisterReadOnly("TempText", typeof(string), typeof(MathKeyboardPanel),
            new PropertyMetadata(string.Empty));

    private static void OnTempTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue) return;
        if (d is MathKeyboardPanel q)
        {
            q.NewTempText();
        }
    }

    private void NewTempText()
    {
        TBText = TempText;
    }

    public static readonly DependencyProperty TempTextProperty = TempTextPropertyKey.DependencyProperty;

    public string TempText
    {
        get { return (string)GetValue(TempTextProperty); }
    }

    private static readonly DependencyPropertyKey TempViewPropertyKey =
        DependencyProperty.RegisterReadOnly("TempView", typeof(string), typeof(MathKeyboardPanel),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TempViewProperty = TempViewPropertyKey.DependencyProperty;

    public string TempView
    {
        get { return (string)GetValue(TempViewProperty); }
    }

    private static readonly DependencyPropertyKey TextNodeActivePropertyKey =
        DependencyProperty.RegisterReadOnly("TextNodeActive", typeof(bool), typeof(MathKeyboardPanel),
            new PropertyMetadata(false));

    public static readonly DependencyProperty TextNodeActiveProperty = TextNodeActivePropertyKey.DependencyProperty;

    public bool TextNodeActive
    {
        get { return (bool)GetValue(TextNodeActiveProperty); }
    }

    static MathKeyboardPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MathKeyboardPanel), new FrameworkPropertyMetadata(typeof(MathKeyboardPanel)));
    }

    #endregion


    public override void OnApplyTemplate()
    {
        _grid = Template.FindName(PART_GRID_NAME, this) as Grid;
        if (_grid != null)
        {
            //_popup.Closed += Popup_Closed;
            if (IsOpen) _grid.Focus();
            _grid.PreviewKeyDown += async (s, e) =>
            {
                if (e.Key == Key.Space)
                {
                    if (IsInTextNode())
                    {
                        keyboardMemory.Insert(new StandardLeafNode(" "));
                        await DisplayResultAsync();
                    }
                    e.Handled = true;
                }
                else if (e.Key == Key.Enter)
                {
                    await NewLine();
                    e.Handled = true;
                }
                else if (e.Key == Key.Tab) e.Handled = true;
            };
            _grid.KeyDown += Panel_KeyDown;
            _grid.TextInput += Panel_TextInput;
            _grid.KeyUp += Panel_KeyUp;
            _grid.MouseUp += (s, e) => _grid.Focus();
            _grid.LostKeyboardFocus += (s, e) =>
            {
                if (!IsMouseOver && IsOpen)
                {
                    if (Text != TempText)
                    {
                        var result = MessageBox.Show("Save changes?", "Leave math", MessageBoxButton.YesNoCancel);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                Text = TempText;
                                IsOpen = false;
                                break;
                            case MessageBoxResult.No:
                                IsOpen = false;
                                break;
                            case MessageBoxResult.Cancel:
                                _grid.Focus();
                                break;
                        }
                    }
                    else IsOpen = false;
                }
            };
        }

        _savebtn = Template.FindName(PART_SAVEBTN_NAME, this) as Button;
        if (_savebtn is not null)
        {
            _savebtn.Click += SaveBtn_Click;
        }

        _cancelbtn = Template.FindName(PART_CANCELBTN_NAME, this) as Button;
        if (_cancelbtn is not null)
        {
            _cancelbtn.Click += (s, e) => IsOpen = false;
        }

        _textbtn = Template.FindName(TEXT_BTN_NAME, this) as Button;
        if (_textbtn is not null)
        {
            _textbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetTextNode());
                await DisplayResultAsync();
            };
        }

        _fracbtn = Template.FindName(FRAC_BTN_NAME, this) as Button;
        if (_fracbtn is not null)
        {
            _fracbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetFractionNode());
                await DisplayResultAsync();
            };
        }

        _num0btn = Template.FindName(NUM0_BTN_NAME, this) as Button;
        if (_num0btn is not null)
        {
            _num0btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("0"));
                await DisplayResultAsync();
            };
        }

        _num1btn = Template.FindName(NUM1_BTN_NAME, this) as Button;
        if (_num1btn is not null)
        {
            _num1btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("1"));
                await DisplayResultAsync();
            };
        }

        _num2btn = Template.FindName(NUM2_BTN_NAME, this) as Button;
        if (_num2btn is not null)
        {
            _num2btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("2"));
                await DisplayResultAsync();
            };
        }

        _num3btn = Template.FindName(NUM3_BTN_NAME, this) as Button;
        if (_num3btn is not null)
        {
            _num3btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("3"));
                await DisplayResultAsync();
            };
        }

        _num4btn = Template.FindName(NUM4_BTN_NAME, this) as Button;
        if (_num4btn is not null)
        {
            _num4btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("4"));
                await DisplayResultAsync();
            };
        }

        _num5btn = Template.FindName(NUM5_BTN_NAME, this) as Button;
        if (_num5btn is not null)
        {
            _num5btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("5"));
                await DisplayResultAsync();
            };
        }

        _num6btn = Template.FindName(NUM6_BTN_NAME, this) as Button;
        if (_num6btn is not null)
        {
            _num6btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("6"));
                await DisplayResultAsync();
            };
        }

        _num7btn = Template.FindName(NUM7_BTN_NAME, this) as Button;
        if (_num7btn is not null)
        {
            _num7btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("7"));
                await DisplayResultAsync();
            };
        }

        _num8btn = Template.FindName(NUM8_BTN_NAME, this) as Button;
        if (_num8btn is not null)
        {
            _num8btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("8"));
                await DisplayResultAsync();
            };
        }

        _num9btn = Template.FindName(NUM9_BTN_NAME, this) as Button;
        if (_num9btn is not null)
        {
            _num9btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new DigitNode("9"));
                await DisplayResultAsync();
            };
        }

        _numgtbtn = Template.FindName(NUMGT_BTN_NAME, this) as Button;
        if (_numgtbtn is not null)
        {
            _numgtbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@">"));
                await DisplayResultAsync();
            };
        }

        _numgtebtn = Template.FindName(NUMGTE_BTN_NAME, this) as Button;
        if (_numgtebtn is not null)
        {
            _numgtebtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\geq"));
                await DisplayResultAsync();
            };
        }

        _numltbtn = Template.FindName(NUMLT_BTN_NAME, this) as Button;
        if (_numltbtn is not null)
        {
            _numltbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"<"));
                await DisplayResultAsync();
            };
        }

        _numltebtn = Template.FindName(NUMLTE_BTN_NAME, this) as Button;
        if (_numltebtn is not null)
        {
            _numltebtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\leq"));
                await DisplayResultAsync();
            };
        }

        _numdotbtn = Template.FindName(NUMDOT_BTN_NAME, this) as Button;
        if (_numdotbtn is not null)
        {
            _numdotbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetDecimalSeparatorNode());
                await DisplayResultAsync();
            };
        }

        _numplusbtn = Template.FindName(NUMPLUS_BTN_NAME, this) as Button;
        if (_numplusbtn is not null)
        {
            _numplusbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"+"));
                await DisplayResultAsync();
            };
        }

        _numminusbtn = Template.FindName(NUMMINUS_BTN_NAME, this) as Button;
        if (_numminusbtn is not null)
        {
            _numminusbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"-"));
                await DisplayResultAsync();
            };
        }

        _numtimesbtn = Template.FindName(NUMTIMES_BTN_NAME, this) as Button;
        if (_numtimesbtn is not null)
        {
            _numtimesbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetMultiplicationNode());
                await DisplayResultAsync();
            };
        }

        _numdividebtn = Template.FindName(NUMDIVIDE_BTN_NAME, this) as Button;
        if (_numdividebtn is not null)
        {
            _numdividebtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\div"));
                await DisplayResultAsync();
            };
        }

        _numeqbtn = Template.FindName(NUMEQ_BTN_NAME, this) as Button;
        if (_numeqbtn is not null)
        {
            _numeqbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"="));
                await DisplayResultAsync();
            };
        }

        //_nlbtn = Template.FindName(NEWLINE_BTN_NAME, this) as Button;
        //if (_nlbtn is not null)
        //{
        //    _nlbtn.Click += async (s, e) =>
        //    {
        //        //if (!IsInTextNode()) return;
        //        if (keyboardMemory.Current is StandardBranchingNode)
        //        {
        //            StandardBranchingNode sbn = (StandardBranchingNode)keyboardMemory.Current;
        //            var a = sbn.GetLatex(keyboardMemory, latexConfiguration);

        //            keyboardMemory.Insert(GetTextNode());
        //        }
        //        await DisplayResultAsync();
        //    };
        //}

        _nlbtn = Template.FindName(NEWLINE_BTN_NAME, this) as Button;
        if (_nlbtn is not null)
        {
            _nlbtn.Click += async (s, e) => await NewLine();
        }

        _degbtn = Template.FindName(DEG_BTN_NAME, this) as Button;
        if (_degbtn is not null)
        {
            _degbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetDegreeNode());
                await DisplayResultAsync();
            };
        }

        _sqrtbtn = Template.FindName(SQRT_BTN_NAME, this) as Button;
        if (_sqrtbtn is not null)
        {
            _sqrtbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetSquareRootNode());
                await DisplayResultAsync();
            };
        }

        _nthrtbtn = Template.FindName(NTHRT_BTN_NAME, this) as Button;
        if (_nthrtbtn is not null)
        {
            _nthrtbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetNthRootNode());
                await DisplayResultAsync();
            };
        }

        _infbtn = Template.FindName(INF_BTN_NAME, this) as Button;
        if (_infbtn is not null)
        {
            _infbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\infty"));
                await DisplayResultAsync();
            };
        }

        _sinbtn = Template.FindName(SIN_BTN_NAME, this) as Button;
        if (_sinbtn is not null)
        {
            _sinbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\sin{", "}"));
                await DisplayResultAsync();
            };
        }

        _cosbtn = Template.FindName(COS_BTN_NAME, this) as Button;
        if (_cosbtn is not null)
        {
            _cosbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\cos{", "}"));
                await DisplayResultAsync();
            };
        }

        _tgbtn = Template.FindName(TG_BTN_NAME, this) as Button;
        if (_tgbtn is not null)
        {
            _tgbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\tg{", "}"));
                await DisplayResultAsync();
            };
        }

        _cotgbtn = Template.FindName(COTG_BTN_NAME, this) as Button;
        if (_cotgbtn is not null)
        {
            _cotgbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\cot{", "}"));
                await DisplayResultAsync();
            };
        }

        _inbtn = Template.FindName(IN_BTN_NAME, this) as Button;
        if (_inbtn is not null)
        {
            _inbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\in"));
                await DisplayResultAsync();
            };
        }

        _cupbtn = Template.FindName(CUP_BTN_NAME, this) as Button;
        if (_cupbtn is not null)
        {
            _cupbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\cup"));
                await DisplayResultAsync();
            };
        }

        _capbtn = Template.FindName(CAP_BTN_NAME, this) as Button;
        if (_capbtn is not null)
        {
            _capbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\cap"));
                await DisplayResultAsync();
            };
        }

        _limbtn = Template.FindName(LIM_BTN_NAME, this) as Button;
        if (_limbtn is not null)
        {
            _limbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLimitNode());
                keyboardMemory.Insert(new StandardLeafNode(@"\to"));
                MoveLeft();
                await DisplayResultAsync();
            };
        }

        _limxbtn = Template.FindName(LIMX_BTN_NAME, this) as Button;
        if (_limxbtn is not null)
        {
            _limxbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLimitNode());
                keyboardMemory.Insert(new StandardLeafNode(@"x"));
                keyboardMemory.Insert(new StandardLeafNode(@"\to"));
                await DisplayResultAsync();
            };
        }

        _pibtn = Template.FindName(pi_BTN_NAME, this) as Button;
        if (_pibtn is not null)
        {
            _pibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\pi"));
                await DisplayResultAsync();
            };
        }

        _vecabtn = Template.FindName(veca_BTN_NAME, this) as Button;
        if (_vecabtn is not null)
        {
            _vecabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\vec{", "}"));
                keyboardMemory.Insert(new StandardLeafNode("a"));
                MoveRight();
                await DisplayResultAsync();
            };
        }

        _vecbbtn = Template.FindName(vecb_BTN_NAME, this) as Button;
        if (_vecbbtn is not null)
        {
            _vecbbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\vec{", "}"));
                keyboardMemory.Insert(new StandardLeafNode("b"));
                MoveRight();
                await DisplayResultAsync();
            };
        }

        _veccbtn = Template.FindName(vecc_BTN_NAME, this) as Button;
        if (_veccbtn is not null)
        {
            _veccbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\vec{", "}"));
                keyboardMemory.Insert(new StandardLeafNode("c"));
                MoveRight();
                await DisplayResultAsync();
            };
        }

        _vecbtn = Template.FindName(vec_BTN_NAME, this) as Button;
        if (_vecbtn is not null)
        {
            _vecbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\vec{", "}"));
                await DisplayResultAsync();
            };
        }

        _sysbtn = Template.FindName(sys_BTN_NAME, this) as Button;
        if (_sysbtn is not null)
        {
            _sysbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                //keyboardMemory.Insert(GetSystemNode());
                keyboardMemory.Insert(new StandardLeafNode(@"\left|"));
                keyboardMemory.Insert(new StandardLeafNode(@"{"));
                keyboardMemory.Insert(new StandardLeafNode(@"}"));
                keyboardMemory.Insert(new StandardLeafNode(@"\right."));
                MoveLeft();
                await DisplayResultAsync();
            };
        }

        _casesbtn = Template.FindName(cases_BTN_NAME, this) as Button;
        if (_casesbtn is not null)
        {
            _casesbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                //keyboardMemory.Insert(GetSystemNode());
                keyboardMemory.Insert(new StandardLeafNode(@"\left\{"));
                keyboardMemory.Insert(new StandardLeafNode(@"{"));
                keyboardMemory.Insert(new StandardLeafNode(@"}"));
                keyboardMemory.Insert(new StandardLeafNode(@"\right."));
                MoveLeft();
                await DisplayResultAsync();
            };
        }

        //_infbtn = Template.FindName(INF_BTN_NAME, this) as Button;
        //if (_infbtn is not null)
        //{
        //    _infbtn.Click += async (s, e) =>
        //    {
        //        if (IsInTextNode()) return;
        //        keyboardMemory.Insert(GetLimitNode());
        //        await DisplayResultAsync();
        //    };
        //}

        _toggle = Template.FindName(PART_TOGGLE_NAME, this) as CheckBox;
        if (_toggle is not null)
        {
            _toggle.MouseUp += (s, e) =>
            {
                if (IsOpen)
                    Keyboard.Focus(_grid);
            };
        }

        NewText();

        base.OnApplyTemplate();
    }

    private async Task NewLine()
    {
        if (keyboardMemory.Current is null) return;
        else if (IsInTextNode())
        {
            if (keyboardMemory.Current is Placeholder pl) return;
            else
            {
                if (((TreeNode)keyboardMemory.Current).ParentPlaceholder.ParentNode is StandardBranchingNode brn)
                {
                    if (brn.GetViewModeLatex(latexConfiguration).Contains(@"\text"))
                    {
                        int n = brn.Placeholders[0].Nodes.FindIndex(x => x == keyboardMemory.Current as TreeNode);

                        List<TreeNode> after = brn.Placeholders[0].Nodes[(n + 1)..];

                        brn.Placeholders[0].Nodes.RemoveRange(n + 1, brn.Placeholders[0].Nodes.Count - n - 1);
                        MoveRight();
                        keyboardMemory.Insert(new StandardLeafNode(@"\\"));

                        keyboardMemory.Insert(new StandardBranchingNode(@"\text{", "}"));

                        SyntaxTreeComponent stc = keyboardMemory.Current;
                        keyboardMemory.Insert(after);
                        keyboardMemory.Current = stc;
                    }
                }
            }
        }
        else
        {
            if (keyboardMemory.Current is Placeholder pl && pl.ParentNode is not null && pl.ParentNode is BranchingNode) return;
            else if ((keyboardMemory.Current as TreeNode)?.ParentPlaceholder is not null && (keyboardMemory.Current as TreeNode).ParentPlaceholder != keyboardMemory.SyntaxTreeRoot) return;
            keyboardMemory.Insert(new StandardLeafNode(@"\\"));
        }

        await DisplayResultAsync();
    }

    private async void NewText()
    {
        try
        {
            var parsedNodes = Parse.Latex(Text).SyntaxTreeRoot.Nodes;
            keyboardMemory = new KeyboardMemory
            {

            };
            keyboardMemory.Insert(parsedNodes);
        }
        catch
        {
            var result = MessageBox.Show("Parsing LaTeX failed.\\You have to clear the field\\or exit math mode!\\\\Clear field?", "Parsing failure", MessageBoxButton.YesNo, MessageBoxImage.Error);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Text = "";
                    var parsedNodes2 = Parse.Latex(Text).SyntaxTreeRoot.Nodes;
                    keyboardMemory = new KeyboardMemory
                    {

                    };
                    keyboardMemory.Insert(parsedNodes2);
                    break;
                case MessageBoxResult.No:
                    IsOpen = false;
                    break;
            }
        }

        TBText = Text; 

        await DisplayResultAsync();
    }

    private void Panel_Closed(object sender, EventArgs e)
    {
        if (!_toggle.IsMouseOver)
        {
            IsOpen = false;
        }
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        Text = TempText;
        IsOpen = false;
    }


    #region Nodes
    private StandardLeafNode GetMultiplicationNode() => new StandardLeafNode(".");
    private DecimalSeparatorNode GetDecimalSeparatorNode() => new DecimalSeparatorNode("{,}");
    private static BranchingNode GetFractionNode() => new DescendingBranchingNode(@"\frac{", "}{", "}");
    private static BranchingNode GetBinomialNode() => new DescendingBranchingNode(@"\binom{", "}{", "}");
    private static BranchingNode GetPowerNode() => new AscendingBranchingNode("", "^{", "}");
    private static BranchingNode GetDegreeNode() => new StandardBranchingNode("", @"^{\circ}");
    private static BranchingNode GetSubscriptNode() => new DescendingBranchingNode("", "_{", "}");
    private static BranchingNode GetSquareRootNode() => new StandardBranchingNode(@"\sqrt{", "}");
    private static BranchingNode GetNthRootNode() => new DescendingBranchingNode(@"\sqrt[", "]{", "}");
    private static BranchingNode GetPipesNode() => new StandardBranchingNode(@"\left|", @"\right|");
    private static BranchingNode GetDoublePipesNode() => new StandardBranchingNode(@"\left\|", @"\right\|");
    private static BranchingNode GetCurlyBracketsNode() => new StandardBranchingNode(@"\left\{", @"\right\}");
    private static BranchingNode GetSquareBracketsNode() => new StandardBranchingNode(@"\left[", @"\right]");
    private static BranchingNode GetIntegralNode() => new AscendingBranchingNode(@"\int_{", "}^{", "}");
    private static BranchingNode GetSumNode() => new AscendingBranchingNode(@"\sum_{", "}^{", "}");
    private static BranchingNode GetProductNode() => new AscendingBranchingNode(@"\prod_{", "}^{", "}");
    private static BranchingNode GetLimitNode() => new StandardBranchingNode(@"\lim_{", "}");
    private static BranchingNode GetTextNode() => new StandardBranchingNode(@"\text{", "}");
    //private static BranchingNode GetSystemNode() => new StandardBranchingNode(@"\left|{", @"}\right.");
    //private static BranchingNode GetCasesNode() => new StandardBranchingNode(@"\left{{", @"}\right.");

    #endregion


    public async Task<bool> ShouldIgnorePhysicalKeyPresses()
    {
        return false;
        //return inputTextToParse?.Length > 0 || await JS.InvokeAsync<bool>("document.activeElement.classList.contains", "disable-physical-keypress-math-input-when-focused");
    }

    public bool IsInTextNode()
    {
        if (keyboardMemory.Current is Placeholder pl)
        {
            if (pl.ParentNode is not null && pl.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\text{"))
                return true;
        }
        else if (keyboardMemory.Current is StandardLeafNode leaf)
        {
            if (leaf.ParentPlaceholder is not null && leaf.ParentPlaceholder.ParentNode is not null && leaf.ParentPlaceholder.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\text{"))
                return true;
        }
        return false;
    }

    public async Task OnRealTextInput(string text)
    {
        if (IsInTextNode())
        {
            if (await ShouldIgnorePhysicalKeyPresses())
            {
                return;
            }
            else if (keyboardMemory.InSelectionMode())
            {
                keyboardMemory.LeaveSelectionMode();
            }
            keyboardMemory.Insert(new StandardLeafNode(text));
            await DisplayResultAsync();
        }
    }

    public async Task OnPhysicalKeyDownAsync(string key)
    {
        if (IsInTextNode() && key != "Right" && key != "Left" && key != "Up" && key != "Down" && key != "Back" && key != "Delete")
        {
            if (key == "Insert")
            {
                if (keyboardMemory.Current is Placeholder pl && pl.Nodes.Count == 0)
                {
                    if (pl.Nodes.Count == 0) DelLeft();
                    else MoveLeft();
                }
                else if (((TreeNode)keyboardMemory.Current).ParentPlaceholder.Nodes[^1] == keyboardMemory.Current) MoveRight();
                else
                {
                    Placeholder plh = ((TreeNode)keyboardMemory.Current).ParentPlaceholder;
                    int n = plh.Nodes.FindIndex(x => x == keyboardMemory.Current as TreeNode);

                    List<TreeNode> after = plh.Nodes[(n + 1)..];

                    plh.Nodes.RemoveRange(n + 1, plh.Nodes.Count - n - 1);
                    MoveRight();

                    SyntaxTreeComponent stc = keyboardMemory.Current;

                    keyboardMemory.Insert(new StandardBranchingNode(@"\text{", "}"));
                    keyboardMemory.Insert(after);

                    keyboardMemory.Current = stc;
                }
            }
            else return;
        }
        else if (await ShouldIgnorePhysicalKeyPresses())
        {
            return;
        }
        else if (key.Contains("Shift"))
        {
            inShift = true;
        }
        else if (keyboardMemory.InSelectionMode())
        {
            if (key == "Left")
            {
                keyboardMemory.SelectLeft();
            }
            else if (key == "Right")
            {
                keyboardMemory.SelectRight();
            }
            else if (inShift)
            {
                var handler = SelectionModePhysicalKeydownHandlersForShift.FirstOrDefault(x => x.CanHandle(key));
                if (handler != null)
                {
                    handler?.Handle(keyboardMemory, key);
                    keyboardMemory.LeaveSelectionMode();
                }
                else
                {
                    keyboardMemory.LeaveSelectionMode();
                    PhysicalKeydownHandlersForShift.FirstOrDefault(x => x.CanHandle(key))?.Handle(keyboardMemory, key);
                }
            }
            else
            {
                var handler = SelectionModePhysicalKeydownHandlersNoShift.FirstOrDefault(x => x.CanHandle(key));
                if (handler != null)
                {
                    handler?.Handle(keyboardMemory, key);
                    keyboardMemory.LeaveSelectionMode();
                }
                else
                {
                    keyboardMemory.LeaveSelectionMode();
                    PhysicalKeydownHandlersNoShift.FirstOrDefault(x => x.CanHandle(key))?.Handle(keyboardMemory, key);
                }
            }
        }
        else
        {
            if (!inShift && key == "Oem5")
            {
                //await inputToParse.FocusAsync();
                return;
            }
            else if (inShift)
            {
                PhysicalKeydownHandlersForShift.FirstOrDefault(x => x.CanHandle(key))?.Handle(keyboardMemory, key);
            }
            else
            {
                PhysicalKeydownHandlersNoShift.FirstOrDefault(x => x.CanHandle(key))?.Handle(keyboardMemory, key);
            }
        }

        await DisplayResultAsync();
    }

    public Task OnPhysicalKeyUp(string key)
    {
        if (key.Contains("Shift"))
        {
            inShift = false;
        }
        return Task.CompletedTask;
    }

    private bool inShift = false;

    #region KeyHandlers
    public IEnumerable<PhysicalKeyHandler> PhysicalKeydownHandlersForShift
    {
        get
        {
            yield return new PhysicalKeyHandler("D6", (k, key) => k.InsertWithEncapsulateCurrent(GetPowerNode()));
            yield return new PhysicalKeyHandler("D9", (k, key) => k.Insert(new RoundBracketsNode()));
            yield return new PhysicalKeyHandler("D0", (k, key) => MoveRight());
            yield return new PhysicalKeyHandler("D8", (k, key) => k.Insert(GetMultiplicationNode()));
            yield return new PhysicalKeyHandler("OemPlus", (k, key) => k.Insert(new StandardLeafNode("+")));
            yield return new PhysicalKeyHandler("OemMinus", (k, key) => k.InsertWithEncapsulateCurrent(GetSubscriptNode()));
            yield return new PhysicalKeyHandler("D1", (k, key) => k.Insert(new StandardLeafNode("!")));
            yield return new PhysicalKeyHandler("D5", (k, key) => k.Insert(new StandardLeafNode(@"\%")));
            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 44 && (int)Enum.Parse<Key>(key) <= 69; }, (k, key) => k.Insert(new StandardLeafNode(key)));
            //yield return new PhysicalKeyHandler("Left", (k, key) => k.SelectLeft());
            //yield return new PhysicalKeyHandler("Right", (k, key) => k.SelectRight());
            yield return new PhysicalKeyHandler("Oem5", (k, key) => k.Insert(GetPipesNode()));
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.Insert(GetCurlyBracketsNode()));
            yield return new PhysicalKeyHandler("OemCloseBrackets", (k, key) => MoveRight());
            yield return new PhysicalKeyHandler("OemComma", (k, key) => k.Insert(new StandardLeafNode("<")));
            yield return new PhysicalKeyHandler("OemPeriod", (k, key) => k.Insert(new StandardLeafNode(">")));
            yield return new PhysicalKeyHandler("Oem1", (k, key) => k.Insert(new StandardLeafNode(":")));
        }
    }

    public IEnumerable<PhysicalKeyHandler> PhysicalKeydownHandlersNoShift
    {
        get
        {
            //yield return new PhysicalKeyHandler("D0", (k, key) => k.Insert(new DigitNode("0")));
            //yield return new PhysicalKeyHandler("D1", (k, key) => k.Insert(new DigitNode("1")));
            //yield return new PhysicalKeyHandler("D2", (k, key) => k.Insert(new DigitNode("2")));
            //yield return new PhysicalKeyHandler("D3", (k, key) => k.Insert(new DigitNode("3")));
            //yield return new PhysicalKeyHandler("D4", (k, key) => k.Insert(new DigitNode("4")));
            //yield return new PhysicalKeyHandler("D5", (k, key) => k.Insert(new DigitNode("5")));
            //yield return new PhysicalKeyHandler("D6", (k, key) => k.Insert(new DigitNode("6")));
            //yield return new PhysicalKeyHandler("D7", (k, key) => k.Insert(new DigitNode("7")));
            //yield return new PhysicalKeyHandler("D8", (k, key) => k.Insert(new DigitNode("8")));
            //yield return new PhysicalKeyHandler("D9", (k, key) => k.Insert(new DigitNode("9")));

            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 34 && (int)Enum.Parse<Key>(key) <= 43; }, (k, key) => k.Insert(new DigitNode(key[^1].ToString())));
            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 74 && (int)Enum.Parse<Key>(key) <= 83; }, (k, key) => k.Insert(new DigitNode(key[^1].ToString())));
            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 44 && (int)Enum.Parse<Key>(key) <= 69; }, (k, key) => k.Insert(new StandardLeafNode(key.ToLower)));
            yield return new PhysicalKeyHandler("Back", (k, key) => DelLeft());
            yield return new PhysicalKeyHandler("Delete", (k, key) => DelRight());
            yield return new PhysicalKeyHandler("Left", (k, key) => MoveLeft());
            yield return new PhysicalKeyHandler("Right", (k, key) => MoveRight());
            yield return new PhysicalKeyHandler("Up", (k, key) => k.MoveUp());
            yield return new PhysicalKeyHandler("Down", (k, key) => k.MoveDown());
            yield return new PhysicalKeyHandler("OemQuestion", (k, key) => k.InsertWithEncapsulateCurrent(GetFractionNode(), InsertWithEncapsulateCurrentOptions.DeleteOuterRoundBracketsIfAny));
            yield return new PhysicalKeyHandler("Add", (k, key) => k.Insert(new StandardLeafNode("+")));
            yield return new PhysicalKeyHandler("Multiply", (k, key) => k.Insert(GetMultiplicationNode()));
            yield return new PhysicalKeyHandler("Divide", (k, key) => k.Insert(new StandardLeafNode(":")));
            yield return new PhysicalKeyHandler("OemPlus", (k, key) => k.Insert(new StandardLeafNode("=")));
            yield return new PhysicalKeyHandler((key) => key == "OemMinus"|| key == "Subtract", (k, key) => k.Insert(new StandardLeafNode("-")));
            yield return new PhysicalKeyHandler((key) => key == "OemPeriod" || key == "OemComma" || key == "Decimal", (k, key) => k.Insert(GetDecimalSeparatorNode()));
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.Insert(GetSquareBracketsNode()));
            yield return new PhysicalKeyHandler("OemCloseBrackets", (k, key) => MoveRight());
            yield return new PhysicalKeyHandler("Oem1", (k, key) => k.Insert(new StandardLeafNode(";")));
            yield return new PhysicalKeyHandler("Insert", (k, key) => k.Insert(GetTextNode()));
        }
    }

    public IEnumerable<PhysicalKeyHandler> SelectionModePhysicalKeydownHandlersForShift
    {
        get
        {
            yield return new PhysicalKeyHandler("D6", (k, key) => k.InsertWithEncapsulateSelectionAndPrevious(GetPowerNode()));
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.InsertWithEncapsulateSelection(GetCurlyBracketsNode()));
            yield return new PhysicalKeyHandler("Oem5", (k, key) => k.InsertWithEncapsulateSelection(GetPipesNode()));
            yield return new PhysicalKeyHandler("D9", (k, key) => k.InsertWithEncapsulateSelection(new RoundBracketsNode()));
        }
    }

    public IEnumerable<PhysicalKeyHandler> SelectionModePhysicalKeydownHandlersNoShift
    {
        get
        {
            yield return new PhysicalKeyHandler("Back", (k, key) => k.DeleteSelection());
            yield return new PhysicalKeyHandler("Delete", (k, key) => k.DeleteSelection());
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.InsertWithEncapsulateSelection(GetSquareBracketsNode()));
            yield return new PhysicalKeyHandler("OemQuestion", (k, key) => k.InsertWithEncapsulateSelection(GetFractionNode()));
        }
    }
    #endregion


    private async Task DisplayResultAsync()
    {
        if (keyboardMemory.Current is Placeholder p && p.Nodes.Count == 0 && !(p.ParentNode is not null && p.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\text")))
        {
            latexConfiguration.ActivePlaceholderShape = @"\blacksquare";
        }
        else
        {
            latexConfiguration.ActivePlaceholderShape = "|";
        }
        SetValue(TempViewPropertyKey, keyboardMemory.GetEditModeLatex(latexConfiguration));

        SetValue(TempTextPropertyKey, keyboardMemory.GetViewModeLatex(latexConfiguration));

        SetValue(TextNodeActivePropertyKey, IsInTextNode());

        //StateHasChanged();
    }

    private void Panel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        //MessageBox.Show(e.Key.ToString());
        OnPhysicalKeyDownAsync(e.Key.ToString());

        if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
        {
            e.Handled = true;
        }
    }

    private void Panel_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        OnPhysicalKeyUp(e.Key.ToString());
    }

    private void Panel_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        if (e.Text == "\b") return;
        OnRealTextInput(e.Text);
    }

    public Action<KeyboardMemory, TreeNode> InsertAction { get; set; } = (k, node) => k.Insert(node);

    public MathTextboxInfo GetMathTextboxInfo() => new MathTextboxInfo
    {
        KeyboardMemory = keyboardMemory,
        LatexConfiguration = latexConfiguration,
        AfterKeyboardMemoryUpdatedAsync = DisplayResultAsync
    };

    public void MoveLeft()
    {
        if (keyboardMemory.Current is not Placeholder && keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == @"\right.")
        {
            Placeholder pl = (keyboardMemory.Current as TreeNode).ParentPlaceholder;
            if (pl is not null)
            {
                if (pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == "}")
                {
                    keyboardMemory.MoveLeft();
                }
            }
        }
        else if (keyboardMemory.Current is not Placeholder && keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == @"{")
        {
            Placeholder pl = (keyboardMemory.Current as TreeNode).ParentPlaceholder;
            if (pl is not null)
            {
                if (pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left|" || pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left\{")
                {
                    keyboardMemory.MoveLeft();
                }
            }
        }
        keyboardMemory.MoveLeft();
    }

    public void MoveRight()
    {
        Placeholder pl;
        if (keyboardMemory.Current is Placeholder) pl = keyboardMemory.Current as Placeholder;
        else pl = (keyboardMemory.Current as TreeNode).ParentPlaceholder;

        if (pl is not null)
        {
            TreeNode treeNode = (keyboardMemory.Current is Placeholder) ? pl.Nodes.FirstOrDefault() : pl.Nodes.FirstAfterOrDefault(keyboardMemory.Current) as TreeNode;
            if (treeNode?.GetViewModeLatex(latexConfiguration) == @"}")
            {
                if (pl.Nodes.FirstAfterOrDefault(treeNode).GetViewModeLatex(latexConfiguration) == @"\right.")
                {
                    keyboardMemory.MoveRight();
                }
            }
            else if (treeNode?.GetViewModeLatex(latexConfiguration) == @"\left|" || treeNode?.GetViewModeLatex(latexConfiguration) == @"\left\{")
            {
                if (pl.Nodes.FirstAfterOrDefault(treeNode).GetViewModeLatex(latexConfiguration) == @"{")
                {
                    keyboardMemory.MoveRight();
                }
            }
        }
        keyboardMemory.MoveRight();
    }

    public void DelLeft()
    {
        if (keyboardMemory.Current is not Placeholder)
        {
            if ((keyboardMemory.Current as TreeNode).GetViewModeLatex(latexConfiguration).Contains(@"\text"))
            {
                MoveLeft();
            }
            else if (keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == (@"\right."))
            {
                MoveLeft();
                DelLeft();
                return;
            }
            else if (keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == "{")
            {
                string temp = (keyboardMemory.Current as TreeNode).ParentPlaceholder.Nodes.FirstBeforeOrDefault(keyboardMemory.Current).GetViewModeLatex(latexConfiguration);
                if ((temp == @"\left|" || temp == @"\left\{") && (keyboardMemory.Current as TreeNode).ParentPlaceholder.Nodes.FirstAfterOrDefault(keyboardMemory.Current).GetViewModeLatex(latexConfiguration) == "}")
                {
                    keyboardMemory.DeleteLeft();
                    keyboardMemory.DeleteLeft();
                    keyboardMemory.DeleteRight();
                    keyboardMemory.DeleteRight();
                }
                return;
            }
        }
        keyboardMemory.DeleteLeft();
    }

    public void DelRight()
    {
        if (keyboardMemory.Current is Placeholder pl1)
        {
            if (pl1.Nodes.Count != 0 && (pl1.Nodes[0].GetViewModeLatex(latexConfiguration).Contains(@"\text") || pl1.Nodes[0].GetViewModeLatex(latexConfiguration) == @"\left|" || pl1.Nodes[0].GetViewModeLatex(latexConfiguration) == @"\left\{"))
            {
                MoveRight();
                DelRight();
                return;
            }
        }
        else if (((TreeNode)keyboardMemory.Current).ParentPlaceholder is not null)
        {
            Placeholder pl = ((TreeNode)keyboardMemory.Current).ParentPlaceholder;
            if (pl.Nodes[^1] != keyboardMemory.Current)
            {
                TreeNode treeNode = pl.Nodes.FirstAfterOrDefault(keyboardMemory.Current) as TreeNode;

                if (treeNode.GetViewModeLatex(latexConfiguration).Contains(@"\text"))
                {
                    MoveRight();
                }
                else if (treeNode.GetViewModeLatex(latexConfiguration) == "}")
                {
                    if (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\right.")
                    {
                        if ((keyboardMemory.Current as TreeNode).GetViewModeLatex(latexConfiguration) == @"{" && (pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left|" || pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left\{"))
                        {
                            keyboardMemory.DeleteRight();
                            keyboardMemory.DeleteRight();
                            keyboardMemory.DeleteLeft();
                            keyboardMemory.DeleteLeft();
                            return;
                        }
                        else return;
                    }
                }
                else if (treeNode.GetViewModeLatex(latexConfiguration) == @"\left|" || treeNode.GetViewModeLatex(latexConfiguration) == @"\left\{")
                {
                    MoveRight();
                    DelRight();
                    return;
                }
            }
        }

        keyboardMemory.DeleteRight();
    }
}

    

#region Helpers

public class MathTextboxInfo
{
    public LatexConfiguration LatexConfiguration { get; set; } = new();
    public KeyboardMemory KeyboardMemory { get; set; } = new();
    public Func<Task> AfterKeyboardMemoryUpdatedAsync { get; set; } = () => throw new ArgumentNullException($"{nameof(MathTextboxInfo)}.{nameof(AfterKeyboardMemoryUpdatedAsync)}");
}

public class PhysicalKeyHandler
{
    private readonly Func<string, bool> _keyPredicate;
    private readonly Action<KeyboardMemory, string> _actionForKeyboardMemoryAndKey;

    public PhysicalKeyHandler(string key, Action<KeyboardMemory, string> actionForKeyboardMemoryAndKey)
    {
        _keyPredicate = (inputKey) => inputKey == key;
        _actionForKeyboardMemoryAndKey = actionForKeyboardMemoryAndKey;
    }

    public PhysicalKeyHandler(Func<string, bool> keyPredicate, Action<KeyboardMemory, string> actionForKeyboardMemoryAndKey)
    {
        _keyPredicate = keyPredicate;
        _actionForKeyboardMemoryAndKey = actionForKeyboardMemoryAndKey;
    }

    public bool CanHandle(string key)
    {
        return _keyPredicate(key);
    }

    public void Handle(KeyboardMemory k, string key)
    {
        _actionForKeyboardMemoryAndKey(k, key);
    }
}

#endregion