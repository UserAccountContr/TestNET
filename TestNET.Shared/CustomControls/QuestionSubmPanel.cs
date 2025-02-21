namespace TestNET.Shared.CustomControls
{
    public class QuestionSubmPanelSH : Control
    {
        static QuestionSubmPanelSH()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelSH), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelSH)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(ShortAnswerQuestion), typeof(QuestionSubmPanelSH),
               new PropertyMetadata(null));

        public ShortAnswerQuestion Question
        {
            get { return (ShortAnswerQuestion)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty TestProperty =
           DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelSH),
               new PropertyMetadata(null));

        public Test Test
        {
            get { return (Test)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
    }

    public class QuestionSubmPanelMC : Control
    {
        static QuestionSubmPanelMC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelMC), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelMC)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(MultipleChoiceQuestion), typeof(QuestionSubmPanelMC),
               new PropertyMetadata(null));

        public MultipleChoiceQuestion Question
        {
            get { return (MultipleChoiceQuestion)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty TestProperty =
           DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelMC),
               new PropertyMetadata(null));

        public Test Test
        {
            get { return (Test)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
    }

    public class QuestionSubmPanelMCM : Control
    {
        static QuestionSubmPanelMCM()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanelMCM), new FrameworkPropertyMetadata(typeof(QuestionSubmPanelMCM)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(MultipleChoiceManyQuestion), typeof(QuestionSubmPanelMCM),
               new PropertyMetadata(null));

        public MultipleChoiceManyQuestion Question
        {
            get { return (MultipleChoiceManyQuestion)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty TestProperty =
           DependencyProperty.Register("Test", typeof(Test), typeof(QuestionSubmPanelMCM),
               new PropertyMetadata(null));

        public Test Test
        {
            get { return (Test)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
    }
}
