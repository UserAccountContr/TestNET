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
               new PropertyMetadata(null));

        public Question Question
        {
            get { return (Question)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }
    }
}
