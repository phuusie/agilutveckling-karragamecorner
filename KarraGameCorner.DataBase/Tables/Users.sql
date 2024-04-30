CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] NVARCHAR (MAX) NOT NULL,
    [Password]    NVARCHAR (MAX) NOT NULL,
    [Alias]       NVARCHAR (MAX) NOT NULL,
    [Address]     NVARCHAR (MAX) NOT NULL,
    [CartId]      INT            NOT NULL,
    [IsAdmin]     BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Carts_CartId] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Carts] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_CartId]
    ON [dbo].[Users]([CartId] ASC);

