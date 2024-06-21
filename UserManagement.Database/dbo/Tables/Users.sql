CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Forename]    NVARCHAR (MAX) NOT NULL,
    [Surname]     NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [IsActive]    BIT            NOT NULL,
    [DateOfBirth] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

