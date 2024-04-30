CREATE TABLE [dbo].[CartItems] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ProductId] INT NOT NULL,
    [CartId]    INT NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Carts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CartItems_CartId]
    ON [dbo].[CartItems]([CartId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CartItems_ProductId]
    ON [dbo].[CartItems]([ProductId] ASC);

