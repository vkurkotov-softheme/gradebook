CREATE TABLE [dbo].[Grade]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GradeName] NVARCHAR(4) NOT NULL, 
    [BeginYear] SMALLINT NOT NULL, 
    [GraduateYear] SMALLINT NOT NULL, 
    [FormMasterId] INT NOT NULL, 
    [Graduated] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Grade_FormMaster_To_User] FOREIGN KEY ([FormMasterId]) REFERENCES [User]([Id])
)
