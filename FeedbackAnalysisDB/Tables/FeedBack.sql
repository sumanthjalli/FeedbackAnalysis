﻿CREATE TABLE [dbo].[FeedBack] (
    [FeedBackId]         INT            IDENTITY (1, 1) NOT NULL,
    [FeedBackCategoryId] INT            NULL,
    [UserId]             INT            NULL,
    [ProductId]          INT            NULL,
    [FeedBackDesc]       NVARCHAR (MAX) NULL,
    [FeedBackIndex]      FLOAT (53)     NULL,
    [StarRating]         INT            NULL,
    [FeatureID]          INT            NULL,
    PRIMARY KEY CLUSTERED ([FeedBackId] ASC),
    FOREIGN KEY ([FeatureID]) REFERENCES [dbo].[Feature] ([FeatureId]),
    FOREIGN KEY ([FeedBackCategoryId]) REFERENCES [dbo].[FeedBackCategory] ([CategoryId]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


GO


GO


GO


GO
