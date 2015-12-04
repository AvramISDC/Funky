CREATE TABLE [dbo].[Comments] (
    [ID]            INT             NOT NULL,
    [Text]          NVARCHAR (300)  NOT NULL,
    [User ID]       INT             NOT NULL,
    [Restaurant ID] INT             NOT NULL,
    [Ratings]       NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([ID] ASC)
);

