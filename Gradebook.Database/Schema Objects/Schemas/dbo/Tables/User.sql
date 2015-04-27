CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(254) NULL, 
    [PasswordHash] CHAR(32) NULL, 
    [LastLogin] DATETIME NULL, 
    [BirthDate] DATE NOT NULL, 
    [LastName] NVARCHAR(35) NOT NULL, 
    [FirstName] NVARCHAR(35) NOT NULL, 
    [MiddleName] NVARCHAR(35) NOT NULL, 
    [ResidentalAdress] NVARCHAR(150) NULL, 
    [RegisteredAdress] NVARCHAR(150) NULL, 
    [Phone] NVARCHAR(35) NULL, 
    [HomePhone] NVARCHAR(35) NULL, 
    [GradeId] INT NULL, 
    [JobTitle] NVARCHAR(50) NULL, 
    [Relationship] NVARCHAR(50) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [UserType] NVARCHAR(50) NOT NULL DEFAULT 'BASEUSER', 
    [IsParent] BIT NULL, 
    [IsAdministrator] BIT NULL, 
    CONSTRAINT [CK_Email_PasswordHash] CHECK ([Email] IS NULL AND [PasswordHash] IS NULL OR [Email] IS NOT NULL AND [PasswordHash] IS NOT NULL), 
    CONSTRAINT [FK_User_PupilGrade_To_GradeTable] FOREIGN KEY ([GradeId]) REFERENCES [Grade]([Id])
)
