namespace TestNET.Shared.Service;

using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

public class IndexDB
{
    private SqliteConnection _connection;

    public IndexDB()
    {
        _connection = new SqliteConnection($"Data Source='__index__.db'") ?? throw new IOException("Could not open/create database.");
        _connection.Open();
    }
    
    public ObservableCollection<TeacherTest> LoadTests()
    {
        throw new NotImplementedException();
    }

    public void SaveTests(ObservableCollection<TeacherTest> tests)
    {
        Init();
    }

    public TestDB CreateTest()
    {
        string path = $"{Guid.NewGuid()}.db";

        var command = _connection.CreateCommand();
        
        command.CommandText = @"
            INSERT INTO index (name, path)
            VALUES (@path);
        ";

        command.Parameters.AddWithValue("@path", path);

        command.ExecuteNonQuery();

        return new TestDB(path);
    }

    public void DeleteTest(TestDB test)
    {

    }

    private void Init()
    {
        var command = _connection.CreateCommand();

        command.CommandText = $@"
            CREATE TABLE IF NOT EXISTS index (
                id INTEGER PRIMARY KEY,
                path TEXT NOT NULL
            );
        ";

        command.ExecuteNonQuery();
    }
}

public class TestDB
{
    private SqliteConnection _connection;

    public TestDB(string filename)
    {
        _connection = new SqliteConnection($"Data Source='{filename}'") ?? throw new IOException("Could not open/create database.");
        _connection.Open();
    }

    public void SaveTest(TeacherTest test)
    {
        Init(test.Name);

        foreach (Question question in test.Questions ?? [])
        {
            AddQuestion(question);
        }

        foreach (Submission submission in test.Submissions ?? [])
        {
            AddSubmission(submission);
        }
    }

    public TeacherTest LoadTest()
    {
        var command = _connection.CreateCommand();

        command.CommandText = @"
            SELECT name FROM meta;
        ";

        var name = ReadRows(command, 0).First()?.First() ?? throw new InvalidDataException("Test name was null");

        command = _connection.CreateCommand();

        command.CommandText = @"
            SELECT question FROM questions;
        ";

        var questionRows = ReadRows(command, 0, 1);
        ObservableCollection<Question> questions = [];

        foreach (var questionRow in questionRows)
        {
            questions.Add(JsonSerializer.Deserialize<Question>(questionRow[0]) ?? throw new InvalidDataException("The JSON deserialization failed."));
        }

        command = _connection.CreateCommand();

        command.CommandText = @"
            SELECT answers, username, submission_time FROM submissions;
        ";

        var submissionRows = ReadRows(command, 0, 1);
        ObservableCollection<Submission> submissions = [];

        foreach (var submission in submissionRows)
        {
            command = _connection.CreateCommand();

            command.CommandText = $@"
                SELECT answer FROM [{submission[0]}];
            ";

            ObservableCollection<Question> answers = [];

            foreach (var answerRow in ReadRows(command, 0))
            {
                var answer = JsonSerializer.Deserialize<Question>(answerRow[0]) ?? throw new InvalidDataException("The JSON deserialization failed.");
                answers.Add(answer);
            }

            submissions.Add(new(submission[1], new(name, answers), DateTime.Parse(submission[2])));
        }

        return new TeacherTest(
            name,
            questions,
            submissions
            );
    }

    private IEnumerable<string[]> ReadRows(SqliteCommand command, params int[] rowIndices)
    {
        var row = new string[rowIndices.Length];
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                for (int i = 0; i < rowIndices.Length; i++) 
                {
                    row[i] = reader.GetString(rowIndices[i]);
                }

                yield return row;
            }
        }
    }

    private void Init(string name)
    {
        using (var command = _connection.CreateCommand())
        {
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS meta (
                    name TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS submissions (
                    id INTEGER PRIMARY KEY,
                    username TEXT NOT NULL,
                    submission_time TEXT NOT NULL,
                    answers TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS questions (
                    id TEXT NOT NULL PRIMARY KEY,
                    question TEXT NOT NULL
                );
            ";

            command.ExecuteNonQuery();
        }

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = $@"
                INSERT INTO meta (name)
                VALUES (@name);
            ";

            command.Parameters.AddWithValue("@name", name);

            command.ExecuteNonQuery();
        }
    }

    private void AddQuestion(Question question)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $@"
            INSERT INTO questions (id, question)
            VALUES (@id, @question);
        ";

        command.Parameters.AddWithValue("@id", question.UniqueId);
        command.Parameters.AddWithValue("@question", JsonSerializer.Serialize(question));

        command.ExecuteNonQuery();
    }

    private void AddSubmission(Submission submission)
    {
        Guid id = Guid.NewGuid();

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = $@"
                CREATE TABLE [{id.ToString()}] (
                    id TEXT NOT NULL PRIMARY KEY,
                    answer TEXT NOT NULL
                );
            ";

            command.ExecuteNonQuery();
        }

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO submissions (
                    username,
                    submission_time,
                    answers)
                VALUES (@username, @start_time, @submission_time, @answers);
            ";

            command.Parameters.AddWithValue("@username", submission.Name);
            command.Parameters.AddWithValue("@submission_time", submission.TimeSubmitted.ToString("U"));
            command.Parameters.AddWithValue("@answers", id.ToString());
            command.ExecuteNonQuery();
        }

        foreach (var answer in submission.Answers.Questions)
        {
            AddAnswerToSubmission(answer, id);
        }
    }

    private void AddAnswerToSubmission(Question answer, Guid id)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $@"
            INSERT INTO [{id.ToString()}] (id, answer)
            VALUES (@id, @answer);
        ";

        command.Parameters.AddWithValue("@id", answer.UniqueId);
        command.Parameters.AddWithValue("@answer", JsonSerializer.Serialize(answer));

        command.ExecuteNonQuery();
    }
}
