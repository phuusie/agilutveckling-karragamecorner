CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [ESRB]        INT            NOT NULL,
    [Picture]     NVARCHAR (MAX) NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Status]      BIT            NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

