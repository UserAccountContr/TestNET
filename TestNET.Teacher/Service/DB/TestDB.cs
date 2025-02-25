using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using TestNET.Teacher.Service.DB.Queries;

namespace TestNET.Teacher.Service.DB;

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
        testQueries.BeginTransaction();

        testQueries.DeleteTest();
        testQueries.InsertMeta(test.Name, DateTime.Now, test.Shuffled);

        int i = 1;
        foreach (var question in test.Questions)
        {
            testQueries.InsertQuestion(question, i++);
        }

        foreach (var submission in test.Submissions)
        {
            testQueries.InsertSubmission(submission, test);
        }

        testQueries.EndTransaction();
    }

    public TeacherTest Load()
    {
        var name = testQueries.SelectCurrentName();
        var shuffled = testQueries.SelectShuffled();
        var questions = testQueries.SelectQuestions();
        var submissions = testQueries.SelectSubmissions();

        return new TeacherTest(
            name, 
            new ObservableCollection<Question>(questions),
            new ObservableCollection<Submission>(submissions),
            shuffled);
    }
}
