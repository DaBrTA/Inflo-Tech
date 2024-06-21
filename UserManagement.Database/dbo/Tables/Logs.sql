CREATE TABLE [dbo].[Logs] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NOT NULL,
    [LogType]    NCHAR (10)     NOT NULL,
    [LogMessage] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC),
);

