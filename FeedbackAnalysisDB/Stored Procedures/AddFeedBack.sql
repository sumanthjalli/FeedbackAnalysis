CREATE PROC [dbo].[AddFeedBack]
@FeedBackCategoryId int,
@UserId int = null,
@ProductId int,
@FeedBackDesc varchar(MAX),
@FeedBackIndex int
AS
INSERT INTO [dbo].[FeedBack]
           ([FeedBackCategoryId]
           ,[UserId]
           ,[ProductId]
           ,[FeedBackDesc]
           ,[FeedBackIndex])
     VALUES
           (@FeedBackCategoryId
           ,@UserId
           ,@ProductId
           ,@FeedBackDesc
           ,@FeedBackIndex)
GO