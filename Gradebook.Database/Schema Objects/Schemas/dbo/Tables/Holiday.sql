CREATE TABLE [dbo].[Holiday]
(
	[Id] INT NOT NULL IDENTITY, 
    [Date] DATETIME NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Holiday] PRIMARY KEY ([Id]) 
)
