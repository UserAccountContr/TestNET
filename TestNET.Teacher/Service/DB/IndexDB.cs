using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNET.Teacher.Service.DB;

using System.Text.RegularExpressions;
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
            if (!File.Exists(path))
            {
                indexQueries.RemoveTest(path);
                continue;
            }

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

        if (!paths.Contains(path))
        {
            indexQueries.InsertTest(test);
        } 
        else
        {
            do {
                var match = Regex.Match(test.Name, @"(.+)\((\d+)\)");

                if (match.Success)
                {
                    int nextId = int.Parse(match.Groups[2].Value) + 1;
                    test.Name = $"{match.Groups[1].Value}({nextId})";
                }
                else
                {
                    test.Name = $"{test.Name}(1)";
                }

                path = $"{test.Name}.db";

            } while (paths.Contains(path));

            indexQueries.InsertTest(test);
        }

        var db = new TestDB(path);
        db.Save(test);
    }

    public void Remove(TeacherTest test)
    {
        var path = $"{test.Name}.db";

        indexQueries.RemoveTest(path);
    }
}
