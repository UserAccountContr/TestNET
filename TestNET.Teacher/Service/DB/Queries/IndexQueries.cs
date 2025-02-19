using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

namespace TestNET.Teacher.Service.DB.Queries;

internal class IndexQueries(string dbPath)
{
    private static string GetEmbeddedResource(string resourceName)
    {
        // MessageBox.Show(string.Join("\n", Assembly.GetExecutingAssembly().GetManifestResourceNames()) + $"\nFetching: {resourceName}\nJoined: TestNET.Teacher.Service.DB.Queries.Index.{resourceName}");
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"TestNET.Teacher.Service.DB.Queries.Index.{resourceName}"))
        {
            using (var reader = new StreamReader(stream))
            {
                var c = reader.ReadToEnd();
                // MessageBox.Show(c);
                return c;
            }
        }
    }

    private Cached<SqliteConnection> connection =
        new(() => {
            var c = new SqliteConnection($"Data Source={dbPath}");
            c.Open();
            return c;
        });
    private SqliteConnection Connection => connection.Value;

    /* private CachedQuery initializeIndexQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Resources", "InitializeIndex.sql"));
    private string InitializeIndexQuery => initializeIndexQuery.Value; */

    public void InitializeIndex()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InitializeIndex.sql");
            command.ExecuteNonQuery();
        }
    }

    public void DeleteIndex()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("DeleteIndex.sql");
            command.ExecuteNonQuery();
        }
    }

    /* private CachedQuery insertTestQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Resources", "InsertTest"));
    private string InsertTestQuery => insertTestQuery.Value; */

    public void InsertTest(TeacherTest test)
    {
        var path = $"{test.Name}.db";

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InsertTest.sql"); ;

            command.Parameters.AddWithValue("$Path", path);
            command.Parameters.AddWithValue("$Name", test.Name);

            command.ExecuteNonQuery();
        }
    }
    public void RemoveTest(string path)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = "DELETE FROM [TestNET.Index] WHERE Path = $Path";

            command.Parameters.AddWithValue("$Path", path);

            command.ExecuteNonQuery();
        }
    }


    /* private CachedQuery selectTestPathsQuery = new(
        Path.Combine(AppContext.BaseDirectory, "Resources", "SelectTestPaths"));
    private string SelectTestPathsQuery => selectTestPathsQuery.Value; */

    public List<string> SelectTestPaths()
    {
        var paths = new List<string>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectTestPaths.sql"); ;

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
