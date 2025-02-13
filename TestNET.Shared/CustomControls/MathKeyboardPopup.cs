using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MathKeyboardEngine;

namespace TestNET.Shared.CustomControls;

[TemplatePart(Name = PART_POPUP_NAME, Type = typeof(Popup))]
[TemplatePart(Name = PART_TOGGLE_NAME, Type = typeof(CheckBox))]
[TemplatePart(Name = PART_SAVEBTN_NAME, Type =typeof(Button))]
[TemplatePart(Name = TEXT_BTN_NAME, Type = typeof(Button))]
public class MathKeyboardPopup : Control
{
    LatexConfiguration latexConfiguration = new LatexConfiguration();
    KeyboardMemory keyboardMemory = new KeyboardMemory();

    private const string PART_POPUP_NAME = "PART_Popup";
    private const string PART_TOGGLE_NAME = "PART_Toggle";
    private const string PART_SAVEBTN_NAME = "SAVE_BTN";
    private const string TEXT_BTN_NAME = "TEXT_BTN";

    private Popup _popup;
    private CheckBox _toggle;
    private Button _savebtn;
    private Button _textbtn;

    #region Properties

    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MathKeyboardPopup q)
        {
            q.OnPropertyChanged();
        }
    }

    private void OnPropertyChanged()
    {
        if (IsOpen == true) _popup.Focus();
    }

    public static readonly DependencyProperty IsOpenProperty =
        DependencyProperty.Register("IsOpen", typeof(bool), typeof(MathKeyboardPopup),
            new PropertyMetadata(false, OnPropertyChanged));

    public bool IsOpen
    {
        get { return (bool)GetValue(IsOpenProperty); }
        set { SetValue(IsOpenProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(MathKeyboardPopup),
            new PropertyMetadata(string.Empty, OnTextEdit));

    private static void OnTextEdit(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue) return;
        if (d is MathKeyboardPopup q)
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
        DependencyProperty.RegisterReadOnly("TempText", typeof(string), typeof(MathKeyboardPopup),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TempTextProperty = TempTextPropertyKey.DependencyProperty;

    public string TempText
    {
        get { return (string)GetValue(TempTextProperty); }
    }

    private static readonly DependencyPropertyKey TempViewPropertyKey =
        DependencyProperty.RegisterReadOnly("TempView", typeof(string), typeof(MathKeyboardPopup),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TempViewProperty = TempViewPropertyKey.DependencyProperty;

    public string TempView
    {
        get { return (string)GetValue(TempViewProperty); }
    }


    static MathKeyboardPopup()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MathKeyboardPopup), new FrameworkPropertyMetadata(typeof(MathKeyboardPopup)));
    }

    #endregion

    public override void OnApplyTemplate()
    {
        _popup = Template.FindName(PART_POPUP_NAME, this) as Popup;
        if (_popup != null)
        {
            _popup.Closed += Popup_Closed;
            _popup.PreviewKeyDown += async (s, e) =>
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
            };
            _popup.KeyDown += Popup_KeyDown;
            _popup.TextInput += Popup_TextInput;
            _popup.KeyUp += Popup_KeyUp;
        }

        _savebtn = Template.FindName(PART_SAVEBTN_NAME, this) as Button;
        if (_savebtn is not null)
        {
            _savebtn.Click += SaveBtn_Click;
        }

        _textbtn = Template.FindName(TEXT_BTN_NAME, this) as Button;
        if (_textbtn is not null)
        {
            _textbtn.Click += (s, e) => keyboardMemory.Insert(GetTextNode());
        }

        _toggle = Template.FindName(PART_TOGGLE_NAME, this) as CheckBox;
        if(_toggle is not null)
        {
            _toggle.MouseUp += (s, e) =>
            {
                if (IsOpen)
                    Keyboard.Focus(_popup);
            };
        }

        NewText();

        base.OnApplyTemplate();
    }

    private async void NewText()
    {
        var parsedNodes = Parse.Latex(Text).SyntaxTreeRoot.Nodes;
        keyboardMemory.SyntaxTreeRoot.Nodes.Clear();
        keyboardMemory.Insert(parsedNodes);

        await DisplayResultAsync();
    }

    private void Popup_Closed(object sender, EventArgs e)
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
            if(pl.ParentNode is not null && pl.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\text{"))
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
        if (IsInTextNode() && key != "Right" && key != "Left" && key != "Up" && key != "Down" && key != "Back")
        {
            return; 
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
            yield return new PhysicalKeyHandler("D0", (k, key) => k.MoveRight());
            yield return new PhysicalKeyHandler("D8", (k, key) => k.Insert(GetMultiplicationNode()));
            yield return new PhysicalKeyHandler("OemPlus", (k, key) => k.Insert(new StandardLeafNode("+")));
            yield return new PhysicalKeyHandler("OemMinus", (k, key) => k.InsertWithEncapsulateCurrent(GetSubscriptNode()));
            yield return new PhysicalKeyHandler("D1", (k, key) => k.Insert(new StandardLeafNode("!")));
            yield return new PhysicalKeyHandler("D5", (k, key) => k.Insert(new StandardLeafNode(@"\%")));
            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 44 && (int)Enum.Parse<Key>(key) <= 69; }, (k, key) => k.Insert(new StandardLeafNode(key)));
            yield return new PhysicalKeyHandler("Left", (k, key) => k.SelectLeft());
            yield return new PhysicalKeyHandler("Right", (k, key) => k.SelectRight());
            yield return new PhysicalKeyHandler("Oem5", (k, key) => k.Insert(GetPipesNode()));
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.Insert(GetCurlyBracketsNode()));
            yield return new PhysicalKeyHandler("OemCloseBrackets", (k, key) => k.MoveRight());
            yield return new PhysicalKeyHandler("OemComma", (k, key) => k.Insert(new StandardLeafNode("<")));
            yield return new PhysicalKeyHandler("OemPeriod", (k, key) => k.Insert(new StandardLeafNode(">")));
            yield return new PhysicalKeyHandler("Oem1", (k, key) => k.Insert(new StandardLeafNode(":")));
        }
    }

    public IEnumerable<PhysicalKeyHandler> PhysicalKeydownHandlersNoShift
    {
        get
        {
            yield return new PhysicalKeyHandler("D0", (k, key) => k.Insert(new DigitNode("0")));
            yield return new PhysicalKeyHandler("D1", (k, key) => k.Insert(new DigitNode("1")));
            yield return new PhysicalKeyHandler("D2", (k, key) => k.Insert(new DigitNode("2")));
            yield return new PhysicalKeyHandler("D3", (k, key) => k.Insert(new DigitNode("3")));
            yield return new PhysicalKeyHandler("D4", (k, key) => k.Insert(new DigitNode("4")));
            yield return new PhysicalKeyHandler("D5", (k, key) => k.Insert(new DigitNode("5")));
            yield return new PhysicalKeyHandler("D6", (k, key) => k.Insert(new DigitNode("6")));
            yield return new PhysicalKeyHandler("D7", (k, key) => k.Insert(new DigitNode("7")));
            yield return new PhysicalKeyHandler("D8", (k, key) => k.Insert(new DigitNode("8")));
            yield return new PhysicalKeyHandler("D9", (k, key) => k.Insert(new DigitNode("9")));
            yield return new PhysicalKeyHandler((key) => { return (int)Enum.Parse<Key>(key) >= 44 && (int)Enum.Parse<Key>(key) <= 69; }, (k, key) => k.Insert(new StandardLeafNode(key.ToLower)));
            yield return new PhysicalKeyHandler("Back", (k, key) => k.DeleteLeft());
            yield return new PhysicalKeyHandler("Delete", (k, key) => k.DeleteRight());
            yield return new PhysicalKeyHandler("Left", (k, key) => k.MoveLeft());
            yield return new PhysicalKeyHandler("Right", (k, key) => k.MoveRight());
            yield return new PhysicalKeyHandler("Up", (k, key) => k.MoveUp());
            yield return new PhysicalKeyHandler("Down", (k, key) => k.MoveDown());
            yield return new PhysicalKeyHandler("OemQuestion", (k, key) => k.InsertWithEncapsulateCurrent(GetFractionNode(), InsertWithEncapsulateCurrentOptions.DeleteOuterRoundBracketsIfAny));
            yield return new PhysicalKeyHandler("OemPlus", (k, key) => k.Insert(new StandardLeafNode("=")));
            yield return new PhysicalKeyHandler("OemMinus", (k, key) => k.Insert(new StandardLeafNode("-")));
            yield return new PhysicalKeyHandler((key) => key == "OemPeriod" || key == "OemComma", (k, key) => k.Insert(GetDecimalSeparatorNode()));
            yield return new PhysicalKeyHandler("OemOpenBrackets", (k, key) => k.Insert(GetSquareBracketsNode()));
            yield return new PhysicalKeyHandler("OemCloseBrackets", (k, key) => k.MoveRight());
            yield return new PhysicalKeyHandler("Oem1", (k, key) => k.Insert(new StandardLeafNode(";")));
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
        if (keyboardMemory.Current is Placeholder p && p.Nodes.Count == 0)
        {
            latexConfiguration.ActivePlaceholderShape = @"\blacksquare";
        }
        else
        {
            latexConfiguration.ActivePlaceholderShape = "|";
        }
        SetValue(TempViewPropertyKey, keyboardMemory.GetEditModeLatex(latexConfiguration));

        SetValue(TempTextPropertyKey, keyboardMemory.GetViewModeLatex(latexConfiguration));
        //StateHasChanged();
    }

    private void Popup_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        //MessageBox.Show(e.Key.ToString());
        OnPhysicalKeyDownAsync(e.Key.ToString());
    }

    private void Popup_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        OnPhysicalKeyUp(e.Key.ToString());
    }

    private void Popup_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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