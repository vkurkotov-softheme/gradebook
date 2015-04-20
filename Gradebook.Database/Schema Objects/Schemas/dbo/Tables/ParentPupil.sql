CREATE TABLE [dbo].[ParentPupil]
(
	[ParentId] INT NOT NULL , 
    [PupilId] INT NOT NULL, 
    PRIMARY KEY ([ParentId], [PupilId]), 
    CONSTRAINT [FK_ParentPupil_Parent_To_User] FOREIGN KEY ([ParentId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ParentPupil_Pupil_To_User] FOREIGN KEY ([ParentId]) REFERENCES [User]([Id])
)
