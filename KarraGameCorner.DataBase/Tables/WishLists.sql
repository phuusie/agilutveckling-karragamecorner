CREATE TABLE [dbo].[WishLists] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UserId]    INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Status]    BIT NOT NULL,
    CONSTRAINT [PK_WishLists] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WishLists_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WishLists_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_WishLists_ProductId]
    ON [dbo].[WishLists]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_WishLists_UserId]
    ON [dbo].[WishLists]([UserId] ASC);

