CREATE TABLE [dbo].[Company] (
    [CompanyId]   INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

