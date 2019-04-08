CREATE Procedure [dbo].[SP_GetProductFeedBackAnalysis]
As
Begin

;With Result As 
(
select * from Product, FeedBackCategory
)
select * into #Temp
from 
(
Select R.ProductName,R.ProductId,R.CategoryId, R.CategoryDesc, FeedBackIndex,
CASE WHEN ISNULL(FeedBackIndex,'') = '' 
       THEN NULL
       ELSE 
              CASE 
              WHEN ISNULL(FeedBackIndex,0) <= 5 THEN 0 ELSE 1 END
       END    AS Flag from Result R
Left Join FeedBack F ON F.ProductID = R.[ProductId] and F.FeedBackCategoryId = R.CategoryID
Group By R.ProductName, R.CategoryDesc, FeedBackIndex,R.ProductId,R.CategoryId
)t


select ProductName,CategoryDesc,ProductId,CategoryId,
(cast( (Cast(SUM(CASE WHEN Flag = 1 THEN 1 ELSE 0 END) as  decimal(10,2)) * 100)/Count(*) as decimal(10,2)) )AS PosCnt,
(Cast( (Cast(SUM(CASE WHEN Flag = 0 THEN 1 ELSE 0 END) as  decimal(10,2)) * 100)/Count(*) as decimal(10,2)) ) AS NegCnt,
(cast( (Cast(SUM(CASE WHEN Flag = 1 THEN 1 ELSE 0 END) as  decimal(10,2)) * 100)/Count(*) as decimal(10,2)) ) + (Cast( (Cast(SUM(CASE WHEN Flag = 0 THEN 1 ELSE 0 END) as  decimal(10,2)) * 100)/Count(*) as decimal(10,2)) ) as TotalCnt 
from #Temp
Group By ProductName, CategoryDesc,ProductId,CategoryId
Order By ProductName, CategoryDesc

Drop table #Temp

END