using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNET.Shared.Service.DB;

using TestNET.Shared;
using TestNET.Shared.Service.DB.Queries;

public class IndexDB
{
    private IndexQueries indexQueries;

    public IndexDB(string dbPath = ".index.db")
    {
        indexQueries = new(dbPath);
        indexQueries.InitializeIndex();
    }
    
    public List<TestDB> LoadAll()
    {
        var paths = indexQueries.SelectTestPaths();
        var tests = new List<TestDB>();

        foreach (var path in paths)
        {
            tests.Add(new TestDB(path));
        }

        return tests;
    }

    public void Add(TeacherTest test)
    {
        indexQueries.InsertTest(test);
    }

    // Add 'void Remove(TestDB testDb)' later
}
