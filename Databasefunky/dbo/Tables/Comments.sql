CREATE TABLE [dbo].[Comments] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [Text]          NVARCHAR (300)  NULL,
    [User ID]       INT             NOT NULL,
    [Restaurant ID] INT             NOT NULL,
    [Ratings]       INT NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([ID] ASC)
);

