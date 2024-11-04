using System.Text.Json;

namespace TestNET.Teacher.Service;

public class TestService
{
    public async Task<List<Test>> GetTests()
    {
        List<Test> testList = new();

        string filename = Path.Combine(AppContext.BaseDirectory, "tests.json");
        if (File.Exists(filename))
        {
            using Stream stream = File.OpenRead(filename);
            testList = (List<Test>)JsonSerializer.Deserialize(stream, typeof(List<Test>));
        }

        if (testList == null)
            throw new Exception();
        return testList;
    }

    public void SaveTests(List<Test> tests)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "tests.json");

        string jsonString = JsonSerializer.Serialize(tests);

        File.WriteAllText(filePath, jsonString);
    }
}
