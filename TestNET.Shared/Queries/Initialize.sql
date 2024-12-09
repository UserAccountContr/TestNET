CREATE TABLE IF NOT EXISTS Users (
	Id INTEGER PRIMARY KEY AUTOINCREMENT
  	Name TEXT NOT NULL
)

CREATE TABLE IF NOT EXISTS Submissions (
	Id INTEGER PRIMARY KEY AUTOINCREMENT
  	UserId INTEGER FOREIGN KEY
  	StartTime INTEGER -- Unix Timestamps
  	SubmissionTime Integer
  	Answers TEXT NOT NULL -- table name containing the answers
)