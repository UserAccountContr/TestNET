﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

namespace TestNET.Teacher.Service.DB.Queries;

internal class TestQueries(string dbPath)
{
    private CachedConnection connection = new(dbPath);
    private SqliteConnection Connection => connection.Value;

    private static string GetEmbeddedResource(string resourceName)
    {
        // MessageBox.Show(string.Join("\n", Assembly.GetExecutingAssembly().GetManifestResourceNames()) + $"\nFetching: {resourceName}\nJoined: TestNET.Teacher.Service.DB.Queries.Test.{resourceName}");
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"TestNET.Teacher.Service.DB.Queries.Test.{resourceName}"))
        {
            using (var reader = new StreamReader(stream))
            {
                var c = reader.ReadToEnd();
                // MessageBox.Show(c);
                return c;
            }
        }
    }

    /* private CachedQuery initializeTestQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "InitializeTest"));
    private string InitializeTestQuery => initializeTestQuery.Value; */

    public void BeginTransaction()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = "BEGIN TRANSACTION";
            command.ExecuteNonQuery();
        }
    }

    public void EndTransaction()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = "END TRANSACTION";
            command.ExecuteNonQuery();
        }
    }

    public void InitializeTest()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InitializeTest.sql");
            command.ExecuteNonQuery();
        }
    }

    public void DeleteTest()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("DeleteTest.sql");
            command.ExecuteNonQuery();
        }
    }

    /*
    private CachedQuery insertAnswerQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "InsertAnswer"));
    private string InsertAnswerQuery => insertAnswerQuery.Value; */

    public void InsertCorrectAnswers(Test test, long submissionId)
    {
        // $SubmissionId, $QuestionId, $CorrectJson

        foreach (var question in test.Questions)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = GetEmbeddedResource("InsertCorrectAnswers.sql");

                command.Parameters.AddWithValue("$SubmissionId", submissionId);
                command.Parameters.AddWithValue("$QuestionId", question.UniqueId);
                command.Parameters.AddWithValue("$CorrectJson", JsonSerializer.Serialize(question));

                command.ExecuteNonQuery();
            }
        }
    }

    private void InsertAnswer(long submissionId, Question answer, Question correct, int order)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InsertAnswer.sql");

            command.Parameters.AddWithValue("$Submission", submissionId);
            command.Parameters.AddWithValue("$Question", answer.UniqueId);
            command.Parameters.AddWithValue("$Answer", JsonSerializer.Serialize(answer));
            command.Parameters.AddWithValue("$Correct", JsonSerializer.Serialize(correct));
            command.Parameters.AddWithValue("$OrderId", JsonSerializer.Serialize(order));

            command.ExecuteNonQuery();
        }
    }

    /*
    private CachedQuery insertSubmissionQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "InsertSubmission"));
    private string InsertSubmissionQuery => insertSubmissionQuery.Value;*/

    public void InsertSubmission(Submission submission, TeacherTest test)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InsertSubmission.sql");

            command.Parameters.AddWithValue(
                "$Username", submission.Name);
            
            command.Parameters.AddWithValue(
                "$SubmissionTime", submission.TimeSubmitted.ToString("U"));

            command.Parameters.AddWithValue(
                    "$Points", submission.Points);

            command.Parameters.AddWithValue(
                    "$ReviewCode", submission.Code);

            command.Parameters.AddWithValue(
                    "$RequiresAttention", submission.RequiresAttention);

            command.ExecuteNonQuery();
        }

        var submissionId = LastRowId();

        if (submission.CorrectAnswers is null || submission.CorrectAnswers.Questions.Count == 0)
            submission.CorrectAnswers = test.NormalTest();

        int order = 1;
        foreach (var answer in submission.Answers.Questions)
        {
            InsertAnswer(submissionId, answer, submission.CorrectAnswers.Questions.Where(x=>x.UniqueId == answer.UniqueId).FirstOrDefault(), order++);
        }

        //InsertCorrectAnswers(submission.CorrectAnswers, submissionId);
    }

    /*
    private CachedQuery insertMetaQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "InsertMeta"));
    private string InsertMetaQuery => insertMetaQuery.Value; */

    public void InsertMeta(string name, DateTime lastChanged, bool shuffled)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InsertMeta.sql");

            command.Parameters.AddWithValue("$Name", name);
            command.Parameters.AddWithValue("$LastChanged", lastChanged.ToString("U"));
            command.Parameters.AddWithValue("$Shuffled", shuffled);

            command.ExecuteNonQuery();
        }
    }

    /*
    private CachedQuery insertQuestionQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "InsertQuestion"));
    private string InsertQuestionQuery => insertQuestionQuery.Value; */

    public void InsertQuestion(Question question, int order)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("InsertQuestion.sql");

            command.Parameters.AddWithValue(
                "$QuestionJson", JsonSerializer.Serialize(question));

            command.Parameters.AddWithValue(
                "$Id", question.UniqueId);

            command.Parameters.AddWithValue(
                "$OrderId", order);

            command.ExecuteNonQuery();
        }
    }

    /*
    private CachedQuery selectCurrentNameQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "SelectCurrentName"));
    private string SelectCurrentNameQuery => selectCurrentNameQuery.Value;
    */
    public string SelectCurrentName()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectCurrentName.sql");

            return (string)(command.ExecuteScalar() ??
            throw new NullReferenceException(
                "The DB returned null when querying the Name of the Test."
            ));
        }
    }

    public bool SelectShuffled()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectShuffled.sql");

            return Convert.ToBoolean((long)(command.ExecuteScalar() ??
            throw new NullReferenceException(
                "The DB returned null when querying the Name of the Test."
            )));
        }
    }

    /*
    private CachedQuery selectQuestionsQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "SelectQuestions"));
    private string SelectQuestionsQuery => selectQuestionsQuery.Value; */

    public List<Question> SelectQuestions()
    {
        var questions = new List<Question>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectQuestions.sql");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                questions.Add(
                    JsonSerializer.Deserialize<Question>(reader.GetString(0)) ??
                    throw new NullReferenceException(
                        "Json Deserialization of Question failed."
                    )
                );
            }
        }

        return questions;
    }

    /*
    private CachedQuery selectSubmissionAnswersQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "SelectQuestions"));
    private string SelectSubmissionAnswersQuery => selectSubmissionAnswersQuery.Value; */
    private List<Question> SelectSubmissionAnswers(long submissionId)
    {
        var answers = new List<Question>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectSubmissionAnswers.sql");

            command.Parameters.AddWithValue("$SubmissionId", submissionId);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                answers.Add(
                    JsonSerializer.Deserialize<Question>(reader.GetString(0)) ??
                    throw new NullReferenceException(
                        "Json Deserialization of Answer failed."
                    )
                );
            }
        }

        return answers;
    }
    private List<Question> SelectSubmissionCorrectAnswers(long submissionId)
    {
        var answers = new List<Question>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectSubmissionCorrectAnswers.sql");

            command.Parameters.AddWithValue("$SubmissionId", submissionId);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0)) continue;
                answers.Add(
                    JsonSerializer.Deserialize<Question>(reader.GetString(0)) ??
                    throw new NullReferenceException(
                        "Json Deserialization of Answer failed."
                    )
                );
            }
        }

        return answers;
    }

    /*
    private CachedQuery selectSubmissionsQuery = new(Path.Combine(AppContext.BaseDirectory, "Resources", "SelectSubmissions"));
    private string SelectSubmissionsQuery => selectSubmissionsQuery.Value;
    */

    public List<Submission> SelectSubmissions()
    {
        var submissions = new List<Submission>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = GetEmbeddedResource("SelectSubmissions.sql");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var id = reader.GetInt64(0);
                var username = reader.GetString(1);
                var submissionTime = reader.GetString(2);
                var points = reader.GetFloat(3);
                var code = reader.GetString(4);
                var attention = reader.GetInt64(5);

                submissions.Add(new Submission(
                    username,
                    new Test(
                        SelectCurrentName(),
                        new ObservableCollection<Question>(SelectSubmissionAnswers(id))),
                    DateTime.Parse(submissionTime),
                    new Test(
                        SelectCurrentName(),
                        new ObservableCollection<Question>(SelectSubmissionCorrectAnswers(id))),
                    code,
                    Convert.ToBoolean(attention)));
            }
        }

        return submissions;
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
