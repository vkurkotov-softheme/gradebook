CREATE TABLE [dbo].[TeacherSubject]
(
	[TeacherId] INT NOT NULL, 
    [SubjecctId] INT NOT NULL, 
	PRIMARY KEY ([TeacherId], [SubjecctId]), 
    CONSTRAINT [FK_Teacher_To_User] FOREIGN KEY ([TeacherId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Subject_To_Subject] FOREIGN KEY ([SubjecctId]) REFERENCES [User]([Id])
)
