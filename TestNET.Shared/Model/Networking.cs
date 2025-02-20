namespace TestNET.Shared.Model;

[JsonDerivedType(typeof(TestRequest), typeDiscriminator: "testRequest")]
[JsonDerivedType(typeof(SubmissionRequest), typeDiscriminator: "submissionRequest")]
public class Request;

public class TestRequest : Request
{
    public required string StudentName { get; set; }
    public int Code { get; set; }
}

public class SubmissionRequest : Request
{
    public required Submission Submission { get; set; }
}

public class TestResponse
{
    public required string Error { get; set; }
    public Test? Test { get; set; }
}