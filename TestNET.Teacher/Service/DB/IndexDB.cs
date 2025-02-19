using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNET.Teacher.Service.DB;

using TestNET.Shared.Model;
using TestNET.Teacher.Service.DB.Queries;

public class IndexDB
{
    private IndexQueries indexQueries;
    private bool cleaned; 

    public IndexDB(bool cleaned = true, string dbPath = ".index.db.log")
    {
        this.cleaned = cleaned;
        indexQueries = new(dbPath);
        indexQueries.InitializeIndex();
    }

    public void InitialCleanup()
    {
        var paths = indexQueries.SelectTestPaths();

        string[] allFiles = Directory.GetFiles(".", "*.db", SearchOption.AllDirectories);

        foreach (string file in allFiles)
        {
            if (!paths.Contains(Path.GetRelativePath(".", file)))
            {
                File.Delete(file);
            }
        }
    }
    
    public List<TestDB> LoadAll()
    {
        if (!cleaned)
        {
            InitialCleanup();
            cleaned = true;
        }

        var paths = indexQueries.SelectTestPaths();
        var tests = new List<TestDB>();

        foreach (var path in paths)
        {
            tests.Add(new TestDB(path));
        }

        return tests;
    }

    public void Wipe()
    {
        indexQueries.DeleteIndex();
    }

    public void Add(TeacherTest test)
    {
        var paths = indexQueries.SelectTestPaths();

        var path = $"{test.Name}.db";

        var db = new TestDB(path);
        db.Save(test);

        if (!paths.Contains(path))
        {
            indexQueries.InsertTest(test);
        }
    }

    public void Remove(TeacherTest test)
    {
        var path = $"{test.Name}.db";

        indexQueries.RemoveTest(path);
    }
}
