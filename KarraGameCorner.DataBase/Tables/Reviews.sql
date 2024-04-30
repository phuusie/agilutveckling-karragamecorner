CREATE TABLE [dbo].[Reviews] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Rating]      FLOAT (53)     NOT NULL,
    [ProductId]   INT            NOT NULL,
    [UserId]      INT            NOT NULL,
    [ReviewDate]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_ProductId]
    ON [dbo].[Reviews]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_UserId]
    ON [dbo].[Reviews]([UserId] ASC);

