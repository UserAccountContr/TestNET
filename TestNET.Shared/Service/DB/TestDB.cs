using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Service.DB.Queries;

namespace TestNET.Shared.Service.DB;

public class TestDB
{
    private TestQueries testQueries;

    public TestDB(string dbPath)
    {
        testQueries = new(dbPath);
        testQueries.InitializeTest();
    }

    public void Save(TeacherTest test)
    {
        testQueries.InsertMeta(test.Name, DateTime.Now);

        foreach (var question in test.Questions)
        {
            testQueries.InsertQuestion(question);
        }

        foreach (var submission in test.Submissions)
        {
            testQueries.InsertSubmission(submission);
        }
    }

    public TeacherTest Load()
    {
        var name = testQueries.SelectCurrentName();
        var questions = testQueries.SelectQuestions();
        var submissions = testQueries.SelectSubmissions();

        return new TeacherTest(
            name, 
            new ObservableCollection<Question>(questions),
            new ObservableCollection<Submission>(submissions));
    }
}
