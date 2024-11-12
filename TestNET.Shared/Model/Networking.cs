namespace TestNET.Shared.Model;

public class TestRequest 
{
    public required string StudentName { get; set; }
    public int Code { get; set; }
}

public class TestResponse
{
    public required string Error { get; set; }
    public Test? Test { get; set; }
}