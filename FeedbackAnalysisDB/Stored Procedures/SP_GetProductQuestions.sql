Create procedure [dbo].[SP_GetProductQuestions]
(
	@productid int = 0
)
As
Begin

	select * from ProductQuestions where productId is null
	UNION
	select * from ProductQuestions where productId = @productid
End 
GO