CREATE PROC [dbo].[AddFeedBack]
@FeedBackCategoryId int,
@UserId int = null,
@ProductId int,
@FeedBackDesc varchar(MAX) = null,
@FeedBackIndex int,
@StarRating int
AS
INSERT INTO [dbo].[FeedBack]
           ([FeedBackCategoryId]
           ,[UserId]
           ,[ProductId]
           ,[FeedBackDesc]
           ,[FeedBackIndex]
		   ,[StarRating])
     VALUES
           (@FeedBackCategoryId
           ,@UserId
           ,@ProductId
           ,@FeedBackDesc
           ,@FeedBackIndex
		   ,@StarRating)