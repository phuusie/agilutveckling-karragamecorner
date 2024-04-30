CREATE TABLE [dbo].[ProductCategories] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductCategories_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductCategories_ProductId]
    ON [dbo].[ProductCategories]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductCategories_CategoryId]
    ON [dbo].[ProductCategories]([CategoryId] ASC);

