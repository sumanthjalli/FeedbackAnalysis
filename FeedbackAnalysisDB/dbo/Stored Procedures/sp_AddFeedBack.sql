
CREATE PROC [dbo].[sp_AddFeedBack]
@FeedBackCategoryId int,
@UserId int,
@ProductId int,
@FeedBackDesc varchar(MAX),
@FeedBackIndex float
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