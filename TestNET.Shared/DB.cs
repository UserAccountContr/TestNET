namespace TestNET.Shared;

using Microsoft.Data.Sqlite;

public static class DB
{
    public static void Initialize(string dbName)
    {
        using (var connection = new SqliteConnection($"Data Source={dbName}"))
        {
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
    CREATE TABLE IF NOT EXISTS Users (
                        
                    )
                ";
            command.ExecuteNonQuery();
        }
    }
}
