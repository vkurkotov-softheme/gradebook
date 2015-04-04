CREATE TABLE [dbo].[LessonShedule]
(
	[Id] INT NOT NULL IDENTITY, 
    [GradeId] INT NOT NULL, 
    [DayOfWeek] SMALLINT NOT NULL, 
    [LessonNumber] SMALLINT NOT NULL, 
    [SubjectId] INT NOT NULL, 
    [TeacherId] INT NOT NULL, 
    [ClassRoom] NVARCHAR(20) NOT NULL, 
    CONSTRAINT [PK_LessonShedule] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_LessonShedule_Grade_To_Grade] FOREIGN KEY ([GradeId]) REFERENCES [Grade]([Id]), 
    CONSTRAINT [FK_LessonShedule_LessonNumber_Number] FOREIGN KEY ([LessonNumber]) REFERENCES [CallShedule]([Number]), 
    CONSTRAINT [FK_LessonShedule_Subject_To_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id]), 
    CONSTRAINT [FK_LessonShedule_Teacher_To_User] FOREIGN KEY ([TeacherId]) REFERENCES [User]([Id]) 
)
