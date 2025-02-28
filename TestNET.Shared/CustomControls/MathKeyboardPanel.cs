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
[TemplatePart(Name = NOTIN_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NI_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = SUBSET_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = SETM_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NOTHING_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = EXISTS_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = FORALL_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = NEXISTS_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = EXISTS1_BTN_NAME, Type = typeof(Button))]
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
[TemplatePart(Name = SBR_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = SQBR_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = CBR_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = PIPE_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Pi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = pi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = POWERSND_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = POWER_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = INDEX_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = PROC_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = alpha_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Alpha_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = beta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Beta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = gamma_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Gamma_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = delta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Delta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = epsilon_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Epsilon_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = zeta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Zeta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = eta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Eta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = theta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Theta_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = iota_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Iota_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = kappa_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Kappa_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = lambda_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Lambda_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = mu_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Mu_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = nu_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Nu_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = xi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Xi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = rho_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Rho_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = sigma_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Sigma_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = tau_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Tau_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = upsilon_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Upsilon_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = phi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Phi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = chi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Chi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = psi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Psi_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = omega_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = Omega_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = perp_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = parallel_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = ang_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = log_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = log2_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = log10_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = ln_BTN_NAME, Type = typeof(Button))]
public class MathKeyboardPanel : Control
{
    LatexConfiguration latexConfiguration = new ();
    KeyboardMemory keyboardMemory = new ();

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
    private const string Pi_BTN_NAME = "Pi_BTN";
    private const string pi_BTN_NAME = "pi_BTN";
    private const string IN_BTN_NAME = "in_BTN";
    private const string NOTIN_BTN_NAME = "notin_BTN";
    private const string NI_BTN_NAME = "ni_BTN";
    private const string SUBSET_BTN_NAME = "subset_BTN";
    private const string SETM_BTN_NAME = "SETM_BTN";
    private const string NOTHING_BTN_NAME = "NOTHING_BTN";
    private const string EXISTS_BTN_NAME = "EXISTS_BTN";
    private const string FORALL_BTN_NAME = "FORALL_BTN";
    private const string NEXISTS_BTN_NAME = "NEXISTS_BTN";
    private const string EXISTS1_BTN_NAME = "EXISTS1_BTN";
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
    private const string SBR_BTN_NAME = "SBR_BTN";
    private const string SQBR_BTN_NAME = "SQBR_BTN";
    private const string CBR_BTN_NAME = "CBR_BTN";
    private const string PIPE_BTN_NAME = "PIPE_BTN";
    private const string POWERSND_BTN_NAME = "POWERSND_BTN";
    private const string POWER_BTN_NAME = "POWER_BTN";
    private const string INDEX_BTN_NAME = "INDEX_BTN";
    private const string PROC_BTN_NAME = "PROC_BTN";
    private const string alpha_BTN_NAME = "alpha_BTN";
    private const string Alpha_BTN_NAME = "Alpha_BTN";
    private const string beta_BTN_NAME = "beta_BTN";
    private const string Beta_BTN_NAME = "Beta_BTN";
    private const string gamma_BTN_NAME = "gamma_BTN";
    private const string Gamma_BTN_NAME = "Gamma_BTN";
    private const string delta_BTN_NAME = "delta_BTN";
    private const string Delta_BTN_NAME = "Delta_BTN";
    private const string epsilon_BTN_NAME = "epsilon_BTN";
    private const string Epsilon_BTN_NAME = "Epsilon_BTN";
    private const string zeta_BTN_NAME = "zeta_BTN";
    private const string Zeta_BTN_NAME = "Zeta_BTN";
    private const string eta_BTN_NAME = "eta_BTN";
    private const string Eta_BTN_NAME = "Eta_BTN";
    private const string theta_BTN_NAME = "theta_BTN";
    private const string Theta_BTN_NAME = "Theta_BTN";
    private const string iota_BTN_NAME = "iota_BTN";
    private const string Iota_BTN_NAME = "Iota_BTN";
    private const string kappa_BTN_NAME = "kappa_BTN";
    private const string Kappa_BTN_NAME = "Kappa_BTN";
    private const string lambda_BTN_NAME = "lambda_BTN";
    private const string Lambda_BTN_NAME = "Lambda_BTN";
    private const string mu_BTN_NAME = "mu_BTN";
    private const string Mu_BTN_NAME = "Mu_BTN";
    private const string nu_BTN_NAME = "nu_BTN";
    private const string Nu_BTN_NAME = "Nu_BTN";
    private const string xi_BTN_NAME = "xi_BTN";
    private const string Xi_BTN_NAME = "Xi_BTN";
    private const string rho_BTN_NAME = "rho_BTN";
    private const string Rho_BTN_NAME = "Rho_BTN";
    private const string sigma_BTN_NAME = "sigma_BTN";
    private const string Sigma_BTN_NAME = "Sigma_BTN";
    private const string tau_BTN_NAME = "tau_BTN";
    private const string Tau_BTN_NAME = "Tau_BTN";
    private const string upsilon_BTN_NAME = "upsilon_BTN";
    private const string Upsilon_BTN_NAME = "Upsilon_BTN";
    private const string phi_BTN_NAME = "phi_BTN";
    private const string Phi_BTN_NAME = "Phi_BTN";
    private const string chi_BTN_NAME = "chi_BTN";
    private const string Chi_BTN_NAME = "Chi_BTN";
    private const string psi_BTN_NAME = "psi_BTN";
    private const string Psi_BTN_NAME = "Psi_BTN";
    private const string omega_BTN_NAME = "omega_BTN";
    private const string Omega_BTN_NAME = "Omega_BTN";
    private const string perp_BTN_NAME = "perp_BTN";
    private const string parallel_BTN_NAME = "parallel_BTN";
    private const string ang_BTN_NAME = "ANG_BTN";
    private const string log_BTN_NAME = "LOG_BTN";
    private const string log2_BTN_NAME = "LOGTWO_BTN";
    private const string log10_BTN_NAME = "LOGTEN_BTN";
    private const string ln_BTN_NAME = "LN_BTN";

    private Grid? _grid;
    private CheckBox? _toggle;
    private Button? _savebtn;
    private Button? _cancelbtn;
    private Button? _textbtn;
    private Button? _nlbtn;
    private Button? _sqrtbtn;
    private Button? _nthrtbtn;
    private Button? _fracbtn;
    private Button? _degbtn;
    private Button? _infbtn;
    private Button? _sinbtn;
    private Button? _cosbtn;
    private Button? _cupbtn;
    private Button? _capbtn;
    private Button? _tgbtn;
    private Button? _cotgbtn;
    private Button? _limbtn;
    private Button? _limxbtn;
    private Button? _vecabtn;
    private Button? _vecbbtn;
    private Button? _veccbtn;
    private Button? _vecbtn;
    private Button? _pibtn;
    private Button? _pibtn2;
    private Button? _inbtn;
    private Button? _notinbtn;
    private Button? _nibtn;
    private Button? _subsetbtn;
    private Button? _setmbtn;
    private Button? _nothingbtn;
    private Button? _existsbtn;
    private Button? _forallbtn;
    private Button? _nexistsbtn;
    private Button? _exists1btn;
    private Button? _sysbtn;
    private Button? _casesbtn;
    private Button? _num0btn;
    private Button? _num1btn;
    private Button? _num2btn;
    private Button? _num3btn;
    private Button? _num4btn;
    private Button? _num5btn;
    private Button? _num6btn;
    private Button? _num7btn;
    private Button? _num8btn;
    private Button? _num9btn;
    private Button? _numgtbtn;
    private Button? _numgtebtn;
    private Button? _numltbtn;
    private Button? _numltebtn;
    private Button? _numdotbtn;
    private Button? _numplusbtn;
    private Button? _numminusbtn;
    private Button? _numtimesbtn;
    private Button? _numdividebtn;
    private Button? _numeqbtn;
    private Button? _sbrbtn;
    private Button? _sqbrbtn;
    private Button? _cbrbtn;
    private Button? _pipebtn;
    private Button? _powersndbtn;
    private Button? _powerbtn;
    private Button? _indexbtn;
    private Button? _procbtn;
    private Button? _alphabtn;
    private Button? _Alphabtn;
    private Button? _betabtn;
    private Button? _Betabtn;
    private Button? _gammabtn;
    private Button? _Gammabtn;
    private Button? _deltabtn;
    private Button? _Deltabtn;
    private Button? _epsilonbtn;
    private Button? _Epsilonbtn;
    private Button? _zetabtn;
    private Button? _Zetabtn;
    private Button? _etabtn;
    private Button? _Etabtn;
    private Button? _thetabtn;
    private Button? _Thetabtn;
    private Button? _iotabtn;
    private Button? _Iotabtn;
    private Button? _kappabtn;
    private Button? _Kappabtn;
    private Button? _lambdabtn;
    private Button? _Lambdabtn;
    private Button? _mubtn;
    private Button? _Mubtn;
    private Button? _nubtn;
    private Button? _Nubtn;
    private Button? _xibtn;
    private Button? _Xibtn;
    private Button? _rhobtn;
    private Button? _Rhobtn;
    private Button? _sigmabtn;
    private Button? _Sigmabtn;
    private Button? _taubtn;
    private Button? _Taubtn;
    private Button? _upsilonbtn;
    private Button? _Upsilonbtn;
    private Button? _phibtn;
    private Button? _Phibtn;
    private Button? _chibtn;
    private Button? _Chibtn;
    private Button? _psibtn;
    private Button? _Psibtn;
    private Button? _omegabtn;
    private Button? _Omegabtn;
    private Button? _perpbtn;
    private Button? _parallelbtn;
    private Button? _angbtn;
    private Button? _logbtn;
    private Button? _log2btn;
    private Button? _log10btn;
    private Button? _lnbtn;

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
                else if (e.Key == Key.Tab || e.Key == Key.Home || e.Key == Key.PageUp || e.Key == Key.PageDown || e.Key == Key.End) e.Handled = true;
            };
            _grid.KeyDown += Panel_KeyDown;
            _grid.TextInput += Panel_TextInput;
            _grid.KeyUp += Panel_KeyUp;
            _grid.MouseUp += (s, e) => _grid.Focus();
            _grid.LostKeyboardFocus += (s, e) =>
            {
                if (!IsMouseOver && IsOpen && e.NewFocus != null)
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
                                _grid?.Focus();
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
                TextMode();
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
                keyboardMemory.Insert(new StandardLeafNode(@":"));
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

        _sbrbtn = Template.FindName(SBR_BTN_NAME, this) as Button;
        if (_sbrbtn is not null)
        {
            _sbrbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new RoundBracketsNode());
                await DisplayResultAsync();
            };
        }

        _sqbrbtn = Template.FindName(SQBR_BTN_NAME, this) as Button;
        if (_sqbrbtn is not null) {
            _sqbrbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetSquareBracketsNode());
                await DisplayResultAsync();
            };
        }

        _cbrbtn = Template.FindName(CBR_BTN_NAME, this) as Button;
        if (_cbrbtn is not null)
        {
            _cbrbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetCurlyBracketsNode());
                await DisplayResultAsync();
            };
        }

        _pipebtn = Template.FindName(PIPE_BTN_NAME, this) as Button;
        if (_pipebtn is not null)
        {
            _pipebtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetPipesNode());
                await DisplayResultAsync();
            };
        }

        _powersndbtn = Template.FindName(POWERSND_BTN_NAME, this) as Button;
        if (_powersndbtn is not null) {
            _powersndbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.InsertWithEncapsulateCurrent(GetPowerNode());
                keyboardMemory.Insert(new DigitNode(@"2"));
                MoveRight();
                await DisplayResultAsync();
            };
        }

        _powerbtn = Template.FindName(POWER_BTN_NAME, this) as Button;
        if (_powerbtn is not null)
        {
            _powerbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.InsertWithEncapsulateCurrent(GetPowerNode());
                await DisplayResultAsync();
            };
        }

        _indexbtn = Template.FindName(INDEX_BTN_NAME, this) as Button;
        if (_indexbtn is not null) {
            _indexbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.InsertWithEncapsulateCurrent(GetSubscriptNode());
                await DisplayResultAsync();
            };
        }

        _procbtn = Template.FindName(PROC_BTN_NAME, this) as Button;
        if (_procbtn is not null) {
            _procbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\%"));
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

        _notinbtn = Template.FindName(NOTIN_BTN_NAME, this) as Button;
        if (_notinbtn is not null)
        {
            _notinbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\not\in"));
                await DisplayResultAsync();
            };
        }

        _nibtn = Template.FindName(NI_BTN_NAME, this) as Button;
        if (_nibtn is not null)
        {
            _nibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\ni"));
                await DisplayResultAsync();
            };
        }

        _subsetbtn = Template.FindName(SUBSET_BTN_NAME, this) as Button;
        if (_subsetbtn is not null)
        {
            _subsetbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\subset"));
                await DisplayResultAsync();
            };
        }

        _setmbtn = Template.FindName(SETM_BTN_NAME, this) as Button;
        if (_setmbtn is not null)
        {
            _setmbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\setminus"));
                await DisplayResultAsync();
            };
        }

        _nothingbtn = Template.FindName(NOTHING_BTN_NAME, this) as Button;
        if (_nothingbtn is not null) {
            _nothingbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\emptyset"));
                await DisplayResultAsync();
            };
        }

        _existsbtn = Template.FindName(EXISTS_BTN_NAME, this) as Button;
        if (_existsbtn is not null)
        {
            _existsbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\exists"));
                await DisplayResultAsync();
            };
        }

        _forallbtn = Template.FindName(FORALL_BTN_NAME, this) as Button;
        if (_forallbtn is not null)
        {
            _forallbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\forall"));
                await DisplayResultAsync();
            };
        }

        _nexistsbtn = Template.FindName(NEXISTS_BTN_NAME, this) as Button;
        if (_nexistsbtn is not null)
        {
            _nexistsbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\not\exists"));
                await DisplayResultAsync();
            };
        }

        _exists1btn = Template.FindName(EXISTS1_BTN_NAME, this) as Button;
        if (_exists1btn is not null)
        {
            _exists1btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\exists!"));
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
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\pi"));
                await DisplayResultAsync();
            };
        }

        _pibtn2 = Template.FindName(Pi_BTN_NAME, this) as Button;
        if (_pibtn2 is not null)
        {
            _pibtn2.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\pi"));
                await DisplayResultAsync();
            };
        }

        _alphabtn = Template.FindName(alpha_BTN_NAME, this) as Button;
        if (_alphabtn is not null) {
            _alphabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\alpha"));
                await DisplayResultAsync();
            };
        }

        _Alphabtn = Template.FindName(Alpha_BTN_NAME, this) as Button;
        if (_Alphabtn is not null) {
            _Alphabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Alpha"));
                await DisplayResultAsync();
            };
        }

        _betabtn = Template.FindName(beta_BTN_NAME, this) as Button;
        if (_betabtn is not null) {
            _betabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\beta"));
                await DisplayResultAsync();
            };
        }

        _Betabtn = Template.FindName(Beta_BTN_NAME, this) as Button;
        if (_Betabtn is not null)
        {
            _Betabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Beta"));
                await DisplayResultAsync();
            };
        }

        _gammabtn = Template.FindName(gamma_BTN_NAME, this) as Button;
        if (_gammabtn is not null) {
            _gammabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\gamma"));
                await DisplayResultAsync();
            };
        }

        _Gammabtn = Template.FindName(Gamma_BTN_NAME, this) as Button;
        if (_Gammabtn is not null) {
            _Gammabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Gamma"));
                await DisplayResultAsync();
            };
        }

        _deltabtn = Template.FindName(delta_BTN_NAME, this) as Button;
        if (_deltabtn is not null)
        {
            _deltabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\delta"));
                await DisplayResultAsync();
            };
        }

        _Deltabtn = Template.FindName(Delta_BTN_NAME, this) as Button;
        if (_Deltabtn is not null) {
            _Deltabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Delta"));
                await DisplayResultAsync();
            };
        }

        _epsilonbtn = Template.FindName(epsilon_BTN_NAME, this) as Button;
        if (_epsilonbtn is not null) {
            _epsilonbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\varepsilon"));
                await DisplayResultAsync();
            };
        }

        _Epsilonbtn = Template.FindName(Epsilon_BTN_NAME, this) as Button;
        if (_Epsilonbtn is not null) {
            _Epsilonbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Epsilon"));
                await DisplayResultAsync();
            };
        }

        _zetabtn = Template.FindName(zeta_BTN_NAME, this) as Button;
        if (_zetabtn is not null)
        {
            _zetabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\zeta"));
                await DisplayResultAsync();
            };
        }

        _Zetabtn = Template.FindName(Zeta_BTN_NAME, this) as Button;
        if (_Zetabtn is not null)
        {
            _Zetabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Zeta"));
                await DisplayResultAsync();
            };
        }

        _etabtn = Template.FindName(eta_BTN_NAME, this) as Button;
        if (_etabtn is not null)
        {
            _etabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\eta"));
                await DisplayResultAsync();
            };
        }

        _Etabtn = Template.FindName(Eta_BTN_NAME, this) as Button;
        if (_Etabtn is not null) {
            _Etabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Eta"));
                await DisplayResultAsync();
            };
        }

        _thetabtn = Template.FindName(theta_BTN_NAME, this) as Button;
        if (_thetabtn is not null)
        {
            _thetabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\theta"));
                await DisplayResultAsync();
            };
        }

        _Thetabtn = Template.FindName(Theta_BTN_NAME, this) as Button;
        if (_Thetabtn is not null)
        {
            _Thetabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Theta"));
                await DisplayResultAsync();
            };
        }

        _iotabtn = Template.FindName(iota_BTN_NAME, this) as Button;
        if (_iotabtn is not null) {
            _iotabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\iota"));
                await DisplayResultAsync();
            };
        }

        _Iotabtn = Template.FindName(Iota_BTN_NAME, this) as Button;
        if (_Iotabtn is not null)
        {
            _Iotabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Iota"));
                await DisplayResultAsync();
            };
        }

        _kappabtn = Template.FindName(kappa_BTN_NAME, this) as Button;
        if (_kappabtn is not null)
        {
            _kappabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\kappa"));
                await DisplayResultAsync();
            };
        }

        _Kappabtn = Template.FindName(Kappa_BTN_NAME, this) as Button;
        if (_Kappabtn is not null)
        {
            _Kappabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Kappa"));
                await DisplayResultAsync();
            };
        }

        _lambdabtn = Template.FindName(lambda_BTN_NAME, this) as Button;
        if (_lambdabtn is not null)
        {
            _lambdabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\lambda"));
                await DisplayResultAsync();
            };
        }

        _Lambdabtn = Template.FindName(Lambda_BTN_NAME, this) as Button;
        if (_Lambdabtn is not null)
        {
            _Lambdabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Lambda"));
                await DisplayResultAsync();
            };
        }

        _mubtn = Template.FindName(mu_BTN_NAME, this) as Button;
        if (_mubtn is not null) {
            _mubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\mu"));
                await DisplayResultAsync();
            };
        }

        _Mubtn = Template.FindName(Mu_BTN_NAME, this) as Button;
        if (_Mubtn is not null) {

            _Mubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Mu"));
                await DisplayResultAsync();
            };
        }

        _nubtn = Template.FindName(nu_BTN_NAME, this) as Button;
        if (_nubtn is not null) 
        {
            _nubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\nu"));
                await DisplayResultAsync();
            };
        }

        _Nubtn = Template.FindName(Nu_BTN_NAME, this) as Button;
        if (_Nubtn is not null) 
        {
            _Nubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Nu"));
                await DisplayResultAsync();
            };
        }

        _xibtn = Template.FindName(xi_BTN_NAME, this) as Button;
        if (_xibtn is not null) 
        {
            _xibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\xi"));
                await DisplayResultAsync();
            };
        }

        _Xibtn = Template.FindName(Xi_BTN_NAME, this) as Button;
        if (_Xibtn is not null)
        {
            _Xibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Xi"));
                await DisplayResultAsync();
            };
        }

        _rhobtn = Template.FindName(rho_BTN_NAME, this) as Button;
        if (_rhobtn is not null) {
            _rhobtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\rho"));
                await DisplayResultAsync();
            };
        }

        _Rhobtn = Template.FindName(Rho_BTN_NAME, this) as Button;
        if (_Rhobtn is not null) {
            _Rhobtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Rho"));
                await DisplayResultAsync();
            };
        }

        _sigmabtn = Template.FindName(sigma_BTN_NAME, this) as Button;
        if (_sigmabtn is not null) {
            _sigmabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\sigma"));
                await DisplayResultAsync();
            };
        }

        _Sigmabtn = Template.FindName(Sigma_BTN_NAME, this) as Button;
        if (_Sigmabtn is not null) {
            _Sigmabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Sigma"));
                await DisplayResultAsync();
            };
        }

        _taubtn = Template.FindName(tau_BTN_NAME, this) as Button;
        if (_taubtn is not null) {
            _taubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\tau"));
                await DisplayResultAsync();
            };
        }

        _Taubtn = Template.FindName(Tau_BTN_NAME, this) as Button;
        if (_Taubtn is not null) {
            _Taubtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Tau"));
                await DisplayResultAsync();
            };
        }

        _upsilonbtn = Template.FindName(upsilon_BTN_NAME, this) as Button;
        if (_upsilonbtn is not null)
        {
            _upsilonbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\upsilon"));
                await DisplayResultAsync();
            };
        }

        _Upsilonbtn = Template.FindName(Upsilon_BTN_NAME, this) as Button;
        if (_Upsilonbtn is not null) {
            _Upsilonbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Upsilon"));
                await DisplayResultAsync();
            };
        }

        _phibtn = Template.FindName(phi_BTN_NAME, this) as Button;
        if (_phibtn is not null) {
            _phibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\phi"));
                await DisplayResultAsync();
            };
        }

        _Phibtn = Template.FindName(Phi_BTN_NAME, this) as Button;
        if (_Phibtn is not null) {
            _Phibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Phi"));
                await DisplayResultAsync();
            };
        }

        _chibtn = Template.FindName(chi_BTN_NAME, this) as Button;
        if (_chibtn is not null) {
            _chibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\chi"));
                await DisplayResultAsync();
            };
        }

        _Chibtn = Template.FindName(Chi_BTN_NAME, this) as Button;
        if (_Chibtn is not null) {
            _Chibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Chi"));
                await DisplayResultAsync();
            };
        }

        _psibtn = Template.FindName(psi_BTN_NAME, this) as Button;
        if (_psibtn is not null) {
            _psibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\psi"));
                await DisplayResultAsync();
            };
        }

        _Psibtn = Template.FindName(Psi_BTN_NAME, this) as Button;
        if (_Psibtn is not null)
        {
            _Psibtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Psi"));
                await DisplayResultAsync();
            };
        }

        _omegabtn = Template.FindName(omega_BTN_NAME, this) as Button;
        if (_omegabtn is not null)
        {
            _omegabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\omega"));
                await DisplayResultAsync();
            };
        }

        _Omegabtn = Template.FindName(Omega_BTN_NAME, this) as Button;
        if (_Omegabtn is not null)
        {
            _Omegabtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) TextMode();
                keyboardMemory.Insert(new StandardLeafNode(@"\Omega"));
                await DisplayResultAsync();
            };
        }

        _vecabtn = Template.FindName(veca_BTN_NAME, this) as Button;
        if (_vecabtn is not null)
        {
            _vecabtn.Click += async (s, e) =>
            {
                bool temp = IsInTextNode();
                if (temp) TextMode();
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
                bool temp = IsInTextNode();
                if (temp) TextMode();
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
                bool temp = IsInTextNode();
                if (temp) TextMode();
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
                bool temp = IsInTextNode();
                if (temp) TextMode();
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardBranchingNode(@"\vec{", "}"));
                await DisplayResultAsync();
            };
        }

        _parallelbtn = Template.FindName(parallel_BTN_NAME, this) as Button;
        if (_parallelbtn is not null)
        {
            _parallelbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\parallel"));
                await DisplayResultAsync();
            };
        }

        _perpbtn = Template.FindName(perp_BTN_NAME, this) as Button;
        if (_perpbtn is not null)
        {
            _perpbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\perp"));
                await DisplayResultAsync();
            };
        }

        _angbtn = Template.FindName(ang_BTN_NAME, this) as Button;
        if (_angbtn is not null)
        {
            _angbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(new StandardLeafNode(@"\angle"));
                await DisplayResultAsync();
            };
        }

        _logbtn = Template.FindName(log_BTN_NAME, this) as Button;
        if (_logbtn is not null)
        {
            _logbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLogNode());
                await DisplayResultAsync();
            };
        }

        _log2btn = Template.FindName(log2_BTN_NAME, this) as Button;
        if (_log2btn is not null)
        {
            _log2btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLog2Node());
                await DisplayResultAsync();
            };
        }

        _log10btn = Template.FindName(log10_BTN_NAME, this) as Button;
        if (_log10btn is not null)
        {
            _log10btn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLgNode());
                await DisplayResultAsync();
            };
        }

        _lnbtn = Template.FindName(ln_BTN_NAME, this) as Button;
        if (_lnbtn is not null)
        {
            _lnbtn.Click += async (s, e) =>
            {
                if (IsInTextNode()) return;
                keyboardMemory.Insert(GetLnNode());
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
            if (keyboardMemory.Current is Placeholder pl && pl.ParentNode is BranchingNode) return;
            else if ((keyboardMemory.Current as TreeNode)?.ParentPlaceholder is not null && (keyboardMemory.Current as TreeNode)?.ParentPlaceholder != keyboardMemory.SyntaxTreeRoot) return;
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
                //var result = MessageBox.Show("Parsing LaTeX failed.\\You have to clear the field\\or exit math mode!\\\\Clear field?", "Parsing failure", MessageBoxButton.YesNo, MessageBoxImage.Error);
                //switch (result)
                //{
                //    case MessageBoxResult.Yes:
                //        Text = "";
                //        var parsedNodes2 = Parse.Latex(Text).SyntaxTreeRoot.Nodes;
                //        keyboardMemory = new KeyboardMemory
                //        {

                //        };
                //        keyboardMemory.Insert(parsedNodes2);
                //        break;
                //    case MessageBoxResult.No:
                //        IsOpen = false;
                //        break;
                //}
        }

        await DisplayResultAsync();
    }

    private void Panel_Closed(object sender, EventArgs e)
    {
        if (_toggle is not null && !_toggle.IsMouseOver)
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

    private static BranchingNode GetLogNode() => new StandardBranchingNode(@"\log_{", "}");
    private static BranchingNode GetLnNode() => new StandardBranchingNode(@"\ln{", "}");
    private static BranchingNode GetLgNode() => new StandardBranchingNode(@"\lg{", "}");
    private static BranchingNode GetLog2Node() => new StandardBranchingNode(@"\log_2{", "}");
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

    private void TextMode()
    {
        if (IsInTextNode())
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
        else keyboardMemory.Insert(GetTextNode());
    }

    public async Task OnPhysicalKeyDownAsync(string key)
    {
        if (IsInTextNode() && key != "Right" && key != "Left" && key != "Up" && key != "Down" && key != "Back" && key != "Delete")
        {
            if (key == "Insert") TextMode();
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
            yield return new PhysicalKeyHandler("Insert", (k, key) => TextMode());
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

    private async void Panel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        //MessageBox.Show(e.Key.ToString());
        await OnPhysicalKeyDownAsync(e.Key.ToString());

        if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
        {
            e.Handled = true;
        }
    }

    private void Panel_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        OnPhysicalKeyUp(e.Key.ToString());
    }

    private async void Panel_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        if (e.Text == "\b") return;
        await OnRealTextInput(e.Text);
    }

    public Action<KeyboardMemory, TreeNode> InsertAction { get; set; } = (k, node) => k.Insert(node);

    public MathTextboxInfo GetMathTextboxInfo() => new ()
    {
        KeyboardMemory = keyboardMemory,
        LatexConfiguration = latexConfiguration,
        AfterKeyboardMemoryUpdatedAsync = DisplayResultAsync
    };

    public void MoveLeft()
    {
        if (keyboardMemory.Current is not Placeholder && keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == @"\right.")
        {
            Placeholder? pl = (keyboardMemory.Current as TreeNode)?.ParentPlaceholder;
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
            Placeholder? pl = (keyboardMemory.Current as TreeNode)?.ParentPlaceholder;
            if (pl is not null)
            {
                if (pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left|" || pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left\{")
                {
                    keyboardMemory.MoveLeft();
                }
            }
        }
        keyboardMemory.MoveLeft();
        if (keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == @"\not")
            keyboardMemory.MoveLeft();
    }

    public void MoveRight()
    {
        Placeholder? pl;
        if (keyboardMemory.Current is Placeholder) pl = keyboardMemory.Current as Placeholder;
        else pl = (keyboardMemory.Current as TreeNode)?.ParentPlaceholder;

        if (pl is not null)
        {
            TreeNode? treeNode = (keyboardMemory.Current is Placeholder) ? pl.Nodes.FirstOrDefault() : pl.Nodes.FirstAfterOrDefault(keyboardMemory.Current) as TreeNode;
            if (treeNode?.GetViewModeLatex(latexConfiguration) == @"}")
            {
                if (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\right.")
                {
                    keyboardMemory.MoveRight();
                }
            }
            else if (treeNode?.GetViewModeLatex(latexConfiguration) == @"\not" && (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\in" ||
                    pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\exists"))
            {
                keyboardMemory.MoveRight();
            }
            else if (treeNode?.GetViewModeLatex(latexConfiguration) == @"\left|" || treeNode?.GetViewModeLatex(latexConfiguration) == @"\left\{")
            {
                if (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"{")
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
            if (keyboardMemory.Current is TreeNode trn)
            {
                if (trn.GetViewModeLatex(latexConfiguration).Contains(@"\text"))
                {
                    MoveLeft();
                }
                else if (trn.GetViewModeLatex(latexConfiguration) == (@"\right."))
                {
                    MoveLeft();
                    DelLeft();
                    return;
                }
                else if (trn.GetViewModeLatex(latexConfiguration) == @"\to")
                {
                    if (trn.ParentPlaceholder.ParentNode is not null && trn.ParentPlaceholder.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\lim"))
                    {
                        MoveLeft();
                        return;
                    }
                }
                else if (keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == "{")
                {
                    string? temp = (keyboardMemory.Current as TreeNode)?.ParentPlaceholder.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration);
                    if ((temp == @"\left|" || temp == @"\left\{") && (keyboardMemory.Current as TreeNode)?.ParentPlaceholder.Nodes.FirstAfterOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == "}")
                    {
                        keyboardMemory.DeleteLeft();
                        keyboardMemory.DeleteLeft();
                        keyboardMemory.DeleteRight();
                        keyboardMemory.DeleteRight();
                    }
                    return;
                }
            }
        }
        keyboardMemory.DeleteLeft();
        if (keyboardMemory.Current.GetViewModeLatex(latexConfiguration) == @"\not")
            keyboardMemory.DeleteLeft();
    }

    public void DelRight()
    {
        Placeholder? pl;
        if (keyboardMemory.Current is Placeholder) pl = keyboardMemory.Current as Placeholder;
        else pl = (keyboardMemory.Current as TreeNode)?.ParentPlaceholder;

        if (pl != null)
        {
            TreeNode? treeNode = (keyboardMemory.Current is Placeholder) ? pl.Nodes.FirstOrDefault() : pl.Nodes.FirstAfterOrDefault(keyboardMemory.Current) as TreeNode;
            if (treeNode is not null)
                if (treeNode.GetViewModeLatex(latexConfiguration) == @"\left|" || treeNode.GetViewModeLatex(latexConfiguration) == @"\left\{" || treeNode.GetViewModeLatex(latexConfiguration).Contains(@"\text"))
                {
                    MoveRight();
                    DelRight();
                    return;
                }
                else if (treeNode.GetViewModeLatex(latexConfiguration) == @"\not" && (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\in" ||
                    pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\exists"))
                {
                    keyboardMemory.DeleteRight();
                }
                else if (treeNode.GetViewModeLatex(latexConfiguration) == @"\to")
                {
                    if (pl.ParentNode is not null && pl.ParentNode.GetViewModeLatex(latexConfiguration).Contains(@"\lim"))
                    {
                        MoveRight();
                        return;
                    }
                }
                else if (treeNode.GetViewModeLatex(latexConfiguration) == "}")
                {
                    if (pl.Nodes.FirstAfterOrDefault(treeNode)?.GetViewModeLatex(latexConfiguration) == @"\right.")
                    {
                        if ((keyboardMemory.Current as TreeNode)?.GetViewModeLatex(latexConfiguration) == @"{" && (pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left|" || pl.Nodes.FirstBeforeOrDefault(keyboardMemory.Current)?.GetViewModeLatex(latexConfiguration) == @"\left\{"))
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