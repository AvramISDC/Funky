CREATE TABLE [dbo].[Users] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NULL,
    [Birthday]     DATETIME       NOT NULL,
    [Email Adress] NVARCHAR (MAX) NOT NULL,
    [Username]     NVARCHAR (MAX) NOT NULL,
    [Password]     NVARCHAR (30)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

