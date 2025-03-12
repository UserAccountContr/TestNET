namespace TestNET.Avalonia.Shared.Model;

[JsonDerivedType(typeof(TestRequest), typeDiscriminator: "testRequest")]
[JsonDerivedType(typeof(TestReviewRequest), typeDiscriminator: "testReviewRequest")]
[JsonDerivedType(typeof(SubmissionRequest), typeDiscriminator: "submissionRequest")]
public class Request;

public class TestRequest : Request
{
    public required string StudentName { get; set; }
}

public class TestReviewRequest : Request
{
    public required string StudentName { get; set; }
    public required string ReviewCode { get; set; }
}

public class SubmissionRequest : Request
{
    public required Submission Submission { get; set; }
}

public class SubmissionResponse
{
    public required string ReviewCode { get; set; }
}

public class TestResponse
{
    public required string Error { get; set; }
    public Test? Test { get; set; }
}

public class TestReviewResponse
{
    public required string Error { get; set; }
    public string ReviewCode { get; set; }
    public Submission? Subm { get; set; }
}