CREATE TABLE [dbo].[Mark]
(
	[Id] INT NOT NULL IDENTITY, 
    [TeacherId] INT NOT NULL, 
    [PupilId] INT NOT NULL, 
    [Mark] SMALLINT NULL, 
    [SubjectId] INT NOT NULL, 
    [Date] DATE NOT NULL, 
    [LessonNumber] SMALLINT NOT NULL, 
    [IsPresent] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Mark] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Mark_Teacher_To_User] FOREIGN KEY ([TeacherId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Mark_Pupil_To_User] FOREIGN KEY ([PupilId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Mark_Subject_To_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id]), 
    CONSTRAINT [FK_Mark_LessonNumber_Number] FOREIGN KEY ([LessonNumber]) REFERENCES [CallShedule]([Number]), 
    CONSTRAINT [CK_Mark_Mark_IsPresent] CHECK (CASE WHEN [Mark] IS NOT NULL AND [IsPresent] = 0 THEN 0 ELSE 1 END = 1 ) 
)
