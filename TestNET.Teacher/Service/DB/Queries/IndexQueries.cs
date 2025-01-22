using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

namespace TestNET.Teacher.Service.DB.Queries;

internal class IndexQueries(string dbPath)
{
    private Cached<SqliteConnection> connection =
        new(() => {
            var c = new SqliteConnection($"Data Source={dbPath}");
            c.Open();
            return c;
        });
    private SqliteConnection Connection => connection.Value;

    private CachedQuery initializeIndexQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Queries", "Index", "InitializeIndex.sql"));
    private string InitializeIndexQuery => initializeIndexQuery.Value;

    public void InitializeIndex()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InitializeIndexQuery;
            command.ExecuteNonQuery();
        }
    }

    private CachedQuery insertTestQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Queries", "Index", "InsertTest.sql"));
    private string InsertTestQuery => insertTestQuery.Value;

    public long InsertTest(TeacherTest test)
    {
        var path = $"{new Guid().ToString()}.db";

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InsertTestQuery;

            command.Parameters.AddWithValue("$Path", path);
            command.Parameters.AddWithValue("$Name", test.Name);

            command.ExecuteNonQuery();
        }

        var testQueries = new TestQueries(path);
        testQueries.InitializeTest();

        testQueries.InsertMeta(test.Name, DateTime.Now);
        
        foreach (var submission in test.Submissions)
        {
            testQueries.InsertSubmission(submission);
        }

        foreach (var question in test.Questions)
        {
            testQueries.InsertQuestion(question);
        }

        return LastRowId();
    }

    private CachedQuery selectTestPathsQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Queries", "Index", "SelectTestPaths.sql"));
    private string SelectTestPathsQuery => selectTestPathsQuery.Value;

    public List<string> SelectTestPaths()
    {
        var paths = new List<string>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = SelectTestPathsQuery;

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                paths.Add(reader.GetString(0));
            }
        }

        return paths;
    }

    private long LastRowId()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = "SELECT LAST_INSERT_ROWID();";
            var rowId = (long)(command.ExecuteScalar() ??
            throw new NullReferenceException(
                "The DB returned null when querying the Id of the inserted Row."
            ));

            return rowId;
        }
    }
}
