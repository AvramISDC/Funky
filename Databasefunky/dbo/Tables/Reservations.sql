CREATE TABLE [dbo].[Reservations] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [RestaurantID] INT            NOT NULL,
    [UserID]       NVARCHAR (100) NOT NULL,
    [DateAndTime]  DATETIME       NOT NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([ID] ASC)
);



