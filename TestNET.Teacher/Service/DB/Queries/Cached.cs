using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace TestNET.Teacher.Service.DB.Queries;

internal class Cached<T>(Func<T> get)
{
    private T? value = default;
    public T Value
    {
        get
        {
            if (value == null)
            {
                value = get();
            }

            return value;
        }
    }
}

internal class CachedQuery(string path) : Cached<string>(() => File.ReadAllText(path));
internal class CachedConnection(string dbPath) : Cached<SqliteConnection>(() => 
    {
        var c = new SqliteConnection($"Data Source={dbPath}");
        c.Open();
        return c;
    }
);