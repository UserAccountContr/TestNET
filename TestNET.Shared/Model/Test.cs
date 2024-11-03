namespace TestNET.Shared.Model;

public class Test
{
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
