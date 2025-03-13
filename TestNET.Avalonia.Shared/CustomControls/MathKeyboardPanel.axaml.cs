using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using MathKeyboardEngine;
using MathKeyboardEngine.__Helpers;

namespace TestNET.Avalonia.Shared.CustomControls;

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
[TemplatePart(Name = e_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = arrow_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = binom_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = prim_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = integral_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = sum_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = prod_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = perm_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = vari_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = comb_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = comb_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = prod_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = perm_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = vari_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = noteq_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = MOVEDOWN_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = MOVELEFT_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = MOVEUP_BTN_NAME, Type = typeof(Button))]
[TemplatePart(Name = MOVERIGHT_BTN_NAME, Type = typeof(Button))]
public class MathKeyboardPanel : TemplatedControl
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

    private const string e_BTN_NAME = "E_BTN";
    private const string arrow_BTN_NAME = "arrow_BTN";
    private const string binom_BTN_NAME = "binom_BTN";
    private const string prim_BTN_NAME = "PRIM_BTN";
    private const string integral_BTN_NAME = "INTEGRAL_BTN";
    private const string sum_BTN_NAME = "SUM_BTN";
    private const string prod_BTN_NAME = "PROD_BTN";
    private const string perm_BTN_NAME = "PERM_BTN";
    private const string vari_BTN_NAME = "VARI_BTN";
    private const string comb_BTN_NAME = "COMB_BTN";

    private const string approx_BTN_NAME = "APPROX_BTN";
    private const string cong_BTN_NAME = "CONG_BTN";
    private const string sim_BTN_NAME = "SIM_BTN";
    private const string noteq_BTN_NAME = "NOTEQ_BTN";
    private const string tilde_BTN_NAME = "TILDE_BTN";

    private const string MOVEUP_BTN_NAME = "MOVEUP_BTN";
    private const string MOVELEFT_BTN_NAME = "MOVELEFT_BTN";
    private const string MOVEDOWN_BTN_NAME = "MOVEDOWN_BTN";
    private const string MOVERIGHT_BTN_NAME = "MOVERIGHT_BTN";

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
    private Button? _ebtn;
    private Button? _arrowbtn;
    private Button? _binombtn;
    private Button? _primbtn;
    private Button? _integralbtn;
    private Button? _sumbtn;
    private Button? _prodbtn;
    private Button? _permbtn;
    private Button? _varibtn;
    private Button? _combbtn;
    private Button? _approxbtn;
    private Button? _congbtn;
    private Button? _simbtn;
    private Button? _noteqbtn;
    private Button? _tildebtn;
    private Button? _moveupbtn;
    private Button? _movedownbtn;
    private Button? _moverightbtn;
    private Button? _moveleftbtn;

    #region Properties

    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<MathKeyboardPanel, bool>(nameof(IsOpen), false);

    public bool IsOpen
    {
        get => GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }
    
    public static readonly StyledProperty<string> TextProperty = 
        AvaloniaProperty.Register<MathKeyboardPanel, string>(nameof(Text), string.Empty);

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
}