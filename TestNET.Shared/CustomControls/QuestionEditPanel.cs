namespace TestNET.Shared.CustomControls
{
    public class QuestionEditPanel : Control
    {
        static QuestionEditPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionEditPanel), new FrameworkPropertyMetadata(typeof(QuestionEditPanel)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(Question), typeof(QuestionEditPanel),
               new PropertyMetadata(null, OnQuestionChanged));

        public Question Question
        {
            get { return (Question)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(QuestionEditPanel),
                new PropertyMetadata(false));

        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        private static readonly DependencyPropertyKey QuestionSHPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionSH", typeof(ShortAnswerQuestion), typeof(QuestionEditPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionSHProperty = QuestionSHPropertyKey.DependencyProperty;

        public ShortAnswerQuestion QuestionSH
        {
            get { return (ShortAnswerQuestion)GetValue(QuestionSHProperty); }
        }

        private static readonly DependencyPropertyKey QuestionMCPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionMC", typeof(MultipleChoiceQuestion), typeof(QuestionEditPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionMCProperty = QuestionMCPropertyKey.DependencyProperty;

        public MultipleChoiceQuestion QuestionMC
        {
            get { return (MultipleChoiceQuestion)GetValue(QuestionMCProperty); }
        }

        private static readonly DependencyPropertyKey QuestionMCMPropertyKey =
           DependencyProperty.RegisterReadOnly("QuestionMCM", typeof(MultipleChoiceManyQuestion), typeof(QuestionEditPanel),
               new PropertyMetadata(null));

        public static readonly DependencyProperty QuestionMCMProperty = QuestionMCMPropertyKey.DependencyProperty;

        public MultipleChoiceManyQuestion QuestionMCM
        {
            get { return (MultipleChoiceManyQuestion)GetValue(QuestionMCMProperty); }
        }

        private static void OnQuestionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is QuestionEditPanel q)
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
