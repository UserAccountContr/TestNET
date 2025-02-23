namespace TestNET.Student.ViewModel;

public partial class SubmissionReviewViewModel : BaseViewModel
{
    public SubmissionReviewViewModel(Submission submission)
    {
        Submission = submission;
    }

    [ObservableProperty]
    Submission submission;


}
