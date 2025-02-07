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
}
