CREATE TABLE [dbo].[Equipment]
(
	[name] NVARCHAR(MAX) NOT NULL,
	[empID] INT NOT NULL, 
    [desc] NVARCHAR(MAX) NOT NULL, 
    [phone] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Equipment] PRIMARY KEY ([empID]),

)
