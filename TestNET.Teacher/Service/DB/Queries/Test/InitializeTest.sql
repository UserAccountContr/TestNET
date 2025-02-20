CREATE TABLE IF NOT EXISTS [TestNET.Test.Meta] (
	Id INTEGER NOT NULL,
	Name TEXT NOT NULL,
	LastChanged TEXT NOT NULL,

	PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS [TestNET.Test.Questions] (
  Id TEXT NOT NULL,
  QuestionJson TEXT NOT NULL,
--  OrderId INTEGER NOT NULL,

  PRIMARY KEY (Id)
);

-- CREATE TABLE IF NOT EXISTS [TestNET.Test.Correct] (
--	Id INTEGER NOT NULL,
--	UniqueTestId INTEGER NOT NULL,
--	QuestionId TEXT NOT NULL,
--	CorrectJson TEXT NOT NULL,

--	FOREIGN KEY (QuestionId) REFERENCES [TestNET.Test.Questions] (Id)
-- );

CREATE TABLE IF NOT EXISTS [TestNET.Test.Submissions] (
  Id INTEGER NOT NULL, 
  Username TEXT NOT NULL,
  SubmissionTime TEXT NOT NULL,
  Points FLOAT NOT NULL,
  -- UniqueTestId INTEGER NOT NULL,

  PRIMARY KEY (Id)
  -- FOREIGN KEY (UniqueTestId) REFERENCES [TestNET.Test.Correct]
);

CREATE TABLE IF NOT EXISTS [TestNET.Test.Answers] (
  SubmissionId INTEGER NOT NULL,
  QuestionId TEXT NOT NULL,
  AnswerJson TEXT NOT NULL,

  PRIMARY KEY (SubmissionId, QuestionId),
  
  FOREIGN KEY (SubmissionId) REFERENCES [TestNET.Test.Submissions] (Id), 
  FOREIGN KEY (QuestionId) REFERENCES [TestNET.Test.Questions] (Id)
);