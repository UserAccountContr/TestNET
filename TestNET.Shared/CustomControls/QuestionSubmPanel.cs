namespace TestNET.Shared.CustomControls
{
    public class QuestionSubmPanel : Control
    {
        static QuestionSubmPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuestionSubmPanel), new FrameworkPropertyMetadata(typeof(QuestionSubmPanel)));
        }

        public static readonly DependencyProperty QuestionProperty =
           DependencyProperty.Register("Question", typeof(Question), typeof(QuestionSubmPanel),
               new PropertyMetadata(null));

        public Question Question
        {
            get { return (Question)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }
    }
}
