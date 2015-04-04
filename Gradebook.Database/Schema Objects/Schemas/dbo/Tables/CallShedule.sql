CREATE TABLE [dbo].[CallShedule]
(
    [Number] SMALLINT NOT NULL, 
    [StartTime] TIME NOT NULL, 
    [EndTime] TIME NOT NULL, 
    CONSTRAINT [PK_CallShedule] PRIMARY KEY ([Number])
)
