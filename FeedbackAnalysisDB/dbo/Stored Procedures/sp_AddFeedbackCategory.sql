
CREATE PROC [dbo].[sp_AddFeedbackCategory]
@CategoryId int,
@CategoryDesc varchar(MAX)
as
begin
INSERT INTO [dbo].[FeedBackCategory]
           ([CategoryId]
           ,[CategoryDesc])
     VALUES
           (@CategoryId
           ,@CategoryDesc)
		   end