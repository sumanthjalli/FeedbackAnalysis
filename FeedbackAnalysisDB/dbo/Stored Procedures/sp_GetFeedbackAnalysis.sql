
CREATE procedure [dbo].[sp_GetFeedbackAnalysis]
AS
SELECT F.[FeedBackId]
      ,FC.[CategoryDesc]
      ,U.[UserName]
      ,P.[ProductName]
      ,[FeedBackDesc]
      ,[FeedBackIndex]
  FROM [dbo].[FeedBack] F 
  join [dbo].[FeedBackCategory] FC on F.[FeedBackCategoryId] = FC.[CategoryId]
  join [dbo].[User] U on F.[UserId] = U.[UserId]
  join [dbo].[Product] P on F.[ProductId] = P.[ProductId];