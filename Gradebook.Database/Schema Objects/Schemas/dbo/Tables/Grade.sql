﻿CREATE TABLE [dbo].[Grade]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GradeName] NVARCHAR(4) NOT NULL, 
    [BeginYear] SMALLINT NOT NULL, 
    [GraduateYear] SMALLINT NOT NULL
)
