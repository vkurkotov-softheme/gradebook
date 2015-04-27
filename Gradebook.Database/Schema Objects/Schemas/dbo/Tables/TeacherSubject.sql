CREATE TABLE [dbo].[TeacherSubject]
(
	[TeacherId] INT NOT NULL, 
    [SubjecctId] INT NOT NULL, 
	PRIMARY KEY ([TeacherId], [SubjecctId]), 
    CONSTRAINT [FK_TeacherSubject_Teacher_To_User] FOREIGN KEY ([TeacherId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_TeacherSubject_Subject_To_Subject] FOREIGN KEY ([SubjecctId]) REFERENCES [Subject]([Id])
)
