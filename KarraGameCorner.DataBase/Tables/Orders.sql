CREATE TABLE [dbo].[Orders] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Email]           NVARCHAR (MAX) NOT NULL,
    [OrderDate]       DATETIME2 (7)  NOT NULL,
    [ShippingAddress] NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [TotalPrice]      FLOAT (53)     DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

