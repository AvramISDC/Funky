CREATE TABLE [dbo].[Funkyrestaurants] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [Adress]       NVARCHAR(100)    NOT NULL,
    [AverageStars] FLOAT (53)     NULL
);

