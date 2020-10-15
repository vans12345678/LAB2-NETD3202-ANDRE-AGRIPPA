--Name: Andre Agrippa
--File: midsizellp_db.mdf
--Date: 10/15/2020

CREATE TABLE [dbo].[Equipment] (
    [name]        NVARCHAR (MAX) NOT NULL,
    [empID]       INT            NOT NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    [phone]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED ([empID] ASC)
);

