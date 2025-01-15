﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using TestNET.Shared.Model;

namespace TestNET.Shared.Service.DB.Queries;

internal class TestQueries(string dbPath)
{
    private CachedConnection connection = new(dbPath);
    private SqliteConnection Connection => connection.Value;

    private CachedQuery initializeTestQuery = new("./Queries/Test/InitializeTest.sql");
    private string InitializeTestQuery => initializeTestQuery.Value;

    public void InitializeTest()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InitializeTestQuery;
            command.ExecuteNonQuery();
        }
    }

    private CachedQuery insertAnswerQuery = new("./Queries/Test/InsertAnswer.sql");
    private string InsertAnswerQuery => insertAnswerQuery.Value;

    private void InsertAnswer(long submissionId, Question answer)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InsertAnswerQuery;

            command.Parameters.AddWithValue("$Submission", submissionId);
            command.Parameters.AddWithValue("$Question", answer.UniqueId);
            command.Parameters.AddWithValue("$Answer", JsonSerializer.Serialize(answer));

            command.ExecuteNonQuery();
        }
    }

    private CachedQuery insertSubmissionQuery = new("./Queries/Test/InsertSubmission.sql");
    private string InsertSubmissionQuery => insertSubmissionQuery.Value;

    public void InsertSubmission(Submission submission)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InsertSubmissionQuery;

            command.Parameters.AddWithValue(
                "$Username", submission.Name);
            
            command.Parameters.AddWithValue(
                "$SubmissionTime", submission.TimeSubmitted.ToString("U"));

            command.ExecuteNonQuery();
        }

        foreach (var answer in submission.Answers.Questions)
        {
            InsertAnswer(LastRowId(), answer);
        }
    }

    private CachedQuery insertMetaQuery = new("./Queries/Test/InsertMeta.sql");
    private string InsertMetaQuery => insertMetaQuery.Value;

    public void InsertMeta(string name, DateTime lastChanged)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InsertMetaQuery;

            command.Parameters.AddWithValue("$Name", name);
            command.Parameters.AddWithValue("$LastChanged", lastChanged.ToString("U"));

            command.ExecuteNonQuery();
        }
    }

    private CachedQuery insertQuestionQuery = new("./Queries/Test/InsertMeta.sql");
    private string InsertQuestionQuery => insertQuestionQuery.Value;

    public void InsertQuestion(Question question)
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = InsertQuestionQuery;

            command.Parameters.AddWithValue(
                "$Id", question.UniqueId);
            command.Parameters.AddWithValue(
                "$QuestionJson", JsonSerializer.Serialize(question));

            command.ExecuteNonQuery();
        }
    }

    private CachedQuery selectCurrentNameQuery = new("./Queries/Test/SelectCurrentName.sql");
    private string SelectCurrentNameQuery => selectCurrentNameQuery.Value;
    public string SelectCurrentName()
    {
        using (var command = Connection.CreateCommand())
        {
            command.CommandText = SelectCurrentNameQuery;

            return (string)(command.ExecuteScalar() ??
            throw new NullReferenceException(
                "The DB returned null when querying the Name of the Test."
            ));
        }
    }

    private CachedQuery selectQuestionsQuery = new("./Queries/Test/SelectQuestions.sql");
    private string SelectQuestionsQuery => selectQuestionsQuery.Value;
    public List<Question> SelectQuestions()
    {
        var questions = new List<Question>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = SelectQuestionsQuery;

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

    private CachedQuery selectSubmissionAnswersQuery = new("./Queries/Test/SelectQuestions.sql");
    private string SelectSubmissionAnswersQuery => selectSubmissionAnswersQuery.Value;
    private List<Question> SelectSubmissionAnswers(long submissionId)
    {
        var answers = new List<Question>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = SelectSubmissionAnswersQuery;

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

    private CachedQuery selectSubmissionsQuery = new("./Queries/Test/SelectQuestions.sql");
    private string SelectSubmissionsQuery => selectSubmissionsQuery.Value;
    public List<Submission> SelectSubmissions()
    {
        var submissions = new List<Submission>();

        using (var command = Connection.CreateCommand())
        {
            command.CommandText = SelectSubmissionsQuery;

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var id = reader.GetInt64(0);
                var username = reader.GetString(1);
                var submissionTime = reader.GetString(2);

                submissions.Add(new Submission(
                    username,
                    new Test(
                        SelectCurrentName(),
                        new ObservableCollection<Question>(SelectSubmissionAnswers(id))),
                    DateTime.Parse(submissionTime)));
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
