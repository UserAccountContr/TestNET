namespace TestNET.Shared.DB;

using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

public class DB
{
    private SqliteConnection _connection;

    public DB(string filename)
    {
        _connection = new SqliteConnection($"Data Source='{filename}'") ?? throw new IOException("Could not open/create database.");
        _connection.Open();
    }

    public void Init(string title, string description="")
    {
        using var command = _connection.CreateCommand();
        
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS meta (
                name TEXT NOT NULL,
                description TEXT
            );

            CREATE TABLE IF NOT EXISTS submissions (
                id INTEGER PRIMARY KEY,
                username TEXT NOT NULL,
                start_time TEXT NOT NULL,
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

    public void AddQuestion(Question question)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $@"
            INSERT INTO questions (id, question)
            VALUES (@id, @question);
        ";

        command.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
        command.Parameters.AddWithValue("@question", JsonSerializer.Serialize(question));

        command.ExecuteNonQuery();
    }

    public void Submit(Submission submission)
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
                    start_time,
                    submission_time,
                    answers)
                VALUES (@username, @start_time, @submission_time, @answers);
            ";

            command.Parameters.AddWithValue("@username", submission.Name);
            command.Parameters.AddWithValue("@start_time", submission.TimeSubmitted);
            command.Parameters.AddWithValue("@submission_time", submission.TimeSubmitted);
            command.Parameters.AddWithValue("@answers", id.ToString());
            command.ExecuteNonQuery();
        }

        foreach (var answer in submission.Answers.Questions)
        {
            addAnswerToSubmission(answer, id);
        }
    }

    private void addAnswerToSubmission(Question answer, Guid id)
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
