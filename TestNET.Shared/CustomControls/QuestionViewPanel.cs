namespace TestNET.Shared.CustomControls
{
    public class QuestionViewPanel : Control
    {
        static QuestionViewPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionViewPanel), new FrameworkPropertyMetadata(typeof(QuestionViewPanel)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(Question), typeof(QuestionViewPanel),
               new PropertyMetadata(null, OnQuestionChanged));

        public Question Question
        {
            get { return (Question)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty QuestionIndexProperty =
            DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionViewPanel),
                new PropertyMetadata(0));

        public int QuestionIndex
        {
            get { return (int)GetValue(QuestionIndexProperty); }
            set { SetValue(QuestionIndexProperty, value); }
        }

        public static readonly DependencyProperty ShowAnswersProperty=
            DependencyProperty.Register("ShowAnswers", typeof(bool), typeof(QuestionViewPanel),
                new PropertyMetadata(true));

        public bool ShowAnswers
        {
            get { return (bool)GetValue(ShowAnswersProperty); }
            set { SetValue(ShowAnswersProperty, value); }
        }

        public static readonly DependencyProperty EnableSolvingProperty =
            DependencyProperty.Register("EnableSolving", typeof(bool), typeof(QuestionViewPanel),
                new PropertyMetadata(true));

        public bool EnableSolving
        {
            get { return (bool)GetValue(EnableSolvingProperty); }
            set { SetValue(EnableSolvingProperty, value); }
        }

        private static readonly DependencyPropertyKey QuestionSHPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionSH", typeof(ShortAnswerQuestion), typeof(QuestionViewPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionSHProperty = QuestionSHPropertyKey.DependencyProperty;

        public ShortAnswerQuestion QuestionSH
        {
            get { return (ShortAnswerQuestion)GetValue(QuestionSHProperty); }
        }

        private static readonly DependencyPropertyKey QuestionMCPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionMC", typeof(MultipleChoiceQuestion), typeof(QuestionViewPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionMCProperty = QuestionMCPropertyKey.DependencyProperty;

        public MultipleChoiceQuestion QuestionMC
        {
            get { return (MultipleChoiceQuestion)GetValue(QuestionMCProperty); }
        }

        private static readonly DependencyPropertyKey QuestionMCMPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionMCM", typeof(MultipleChoiceManyQuestion), typeof(QuestionViewPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionMCMProperty = QuestionMCMPropertyKey.DependencyProperty;

        public MultipleChoiceManyQuestion QuestionMCM
        {
            get { return (MultipleChoiceManyQuestion)GetValue(QuestionMCMProperty); }
        }

        private static void OnQuestionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is QuestionViewPanel q)
            {
                q.OnQuestionPropertyChanged();
            }
        }

        private void OnQuestionPropertyChanged()
        {
            if (Question is ShortAnswerQuestion shq) SetValue(QuestionSHPropertyKey, shq);
            if (Question is MultipleChoiceQuestion mcq) SetValue(QuestionMCPropertyKey, mcq);
            if (Question is MultipleChoiceManyQuestion mcmq) SetValue(QuestionMCMPropertyKey, mcmq);
        }
    }

    /*

    public class QuestionViewPanelSH : Control
    {
        static QuestionViewPanelSH()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionViewPanelSH), new FrameworkPropertyMetadata(typeof(QuestionViewPanelSH)));
        }

        public static readonly DependencyProperty QuestionIndexProperty =
            DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionViewPanelSH),
                new PropertyMetadata(0));

        public int QuestionIndex
        {
            get { return (int)GetValue(QuestionIndexProperty); }
            set { SetValue(QuestionIndexProperty, value); }
        }

        public static readonly DependencyProperty ShowAnswersProperty =
            DependencyProperty.Register("ShowAnswers", typeof(bool), typeof(QuestionViewPanelSH),
                new PropertyMetadata(true));

        public bool ShowAnswers
        {
            get { return (bool)GetValue(ShowAnswersProperty); }
            set { SetValue(ShowAnswersProperty, value); }
        }

        public static readonly DependencyProperty EnableSolvingProperty =
            DependencyProperty.Register("EnableSolving", typeof(bool), typeof(QuestionViewPanelSH),
                new PropertyMetadata(true));

        public bool EnableSolving
        {
            get { return (bool)GetValue(EnableSolvingProperty); }
            set { SetValue(EnableSolvingProperty, value); }
        }

        public static readonly DependencyProperty QuestionSHProperty =
           DependencyProperty.Register("QuestionSH", typeof(ShortAnswerQuestion), typeof(QuestionViewPanelSH),
               new PropertyMetadata(null));

        public ShortAnswerQuestion QuestionSH
        {
            get { return (ShortAnswerQuestion)GetValue(QuestionSHProperty); }
            set { SetValue(QuestionSHProperty, value); }
        }
    }

    public class QuestionViewPanelMC : Control
    {
        static QuestionViewPanelMC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionViewPanelMC), new FrameworkPropertyMetadata(typeof(QuestionViewPanelMC)));
        }

        public static readonly DependencyProperty QuestionIndexProperty =
            DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionViewPanelMC),
                new PropertyMetadata(0));

        public int QuestionIndex
        {
            get { return (int)GetValue(QuestionIndexProperty); }
            set { SetValue(QuestionIndexProperty, value); }
        }

        public static readonly DependencyProperty ShowAnswersProperty =
            DependencyProperty.Register("ShowAnswers", typeof(bool), typeof(QuestionViewPanelMC),
                new PropertyMetadata(true));

        public bool ShowAnswers
        {
            get { return (bool)GetValue(ShowAnswersProperty); }
            set { SetValue(ShowAnswersProperty, value); }
        }

        public static readonly DependencyProperty EnableSolvingProperty =
            DependencyProperty.Register("EnableSolving", typeof(bool), typeof(QuestionViewPanelMC),
                new PropertyMetadata(true));

        public bool EnableSolving
        {
            get { return (bool)GetValue(EnableSolvingProperty); }
            set { SetValue(EnableSolvingProperty, value); }
        }

        public static readonly DependencyProperty QuestionMCProperty =
           DependencyProperty.Register("QuestionMC", typeof(MultipleChoiceQuestion), typeof(QuestionViewPanelMC),
               new PropertyMetadata(null));

        public MultipleChoiceQuestion QuestionMC
        {
            get { return (MultipleChoiceQuestion)GetValue(QuestionMCProperty); }
            set { SetValue(QuestionMCProperty, value); }
        }
    }

    public class QuestionViewPanelMCM : Control
    {
        static QuestionViewPanelMCM()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionViewPanelMCM), new FrameworkPropertyMetadata(typeof(QuestionViewPanelMCM)));
        }

        public static readonly DependencyProperty QuestionIndexProperty =
            DependencyProperty.Register("QuestionIndex", typeof(int), typeof(QuestionViewPanelMCM),
                new PropertyMetadata(0));

        public int QuestionIndex
        {
            get { return (int)GetValue(QuestionIndexProperty); }
            set { SetValue(QuestionIndexProperty, value); }
        }

        public static readonly DependencyProperty ShowAnswersProperty =
            DependencyProperty.Register("ShowAnswers", typeof(bool), typeof(QuestionViewPanelMCM),
                new PropertyMetadata(true));

        public bool ShowAnswers
        {
            get { return (bool)GetValue(ShowAnswersProperty); }
            set { SetValue(ShowAnswersProperty, value); }
        }

        public static readonly DependencyProperty EnableSolvingProperty =
            DependencyProperty.Register("EnableSolving", typeof(bool), typeof(QuestionViewPanelMCM),
                new PropertyMetadata(true));

        public bool EnableSolving
        {
            get { return (bool)GetValue(EnableSolvingProperty); }
            set { SetValue(EnableSolvingProperty, value); }
        }

        public static readonly DependencyProperty QuestionMCMProperty =
           DependencyProperty.Register("QuestionMCM", typeof(MultipleChoiceManyQuestion), typeof(QuestionViewPanelMCM),
               new PropertyMetadata(null));

        public MultipleChoiceManyQuestion QuestionMCM
        {
            get { return (MultipleChoiceManyQuestion)GetValue(QuestionMCMProperty); }
            set { SetValue(QuestionMCMProperty, value); }
        }
    }
*/
}