CREATE TABLE [dbo].[Product_Public] (
    [ProductId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProductName] NVARCHAR (MAX) NOT NULL,
    [CompanyId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
);

