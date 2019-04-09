
-- Exec SP_GetCompitatorsFeedBackDetails 2

CREATE Procedure [dbo].[SP_GetCompitatorsFeedBackDetails]
(
	@FeatureId int = 0
)
As
Begin

	;with Temp As
	(		
		select FeedBackCategoryId, FC.CategoryDesc, feedbackId, feedbackDesc, FP.FeatureID, Fet.FeatureName, FP.ProductId, P.ProductName, C.CompanyId, C.CompanyName,
		feedbackindex, starrating, avg((feedbackindex+starrating)/2) as average 
		from FeedBack_public FP
		Left Join FeedbackCategory FC ON FC.CategoryID = FP.FeedBackCategoryId
		Left Join Feature Fet ON Fet.FeatureId = FP.FeatureID
		LEFT JOIN Product_Public P ON P.ProductId = FP.ProductId
		LEFT JOIN Company C ON C.CompanyId = P.CompanyId
		Where FP.FeatureID = @FeatureId
		Group By FeedBackCategoryId, FC.CategoryDesc, feedbackId, feedbackDesc, FP.FeatureID, Fet.FeatureName,
			FP.ProductId, P.ProductName , C.CompanyId, C.CompanyName, feedbackindex, starrating
	)
	
	Select * into #Temp 
	from 
	(
		select FeedBackCategoryId, CategoryDesc, FeatureID, FeatureName, ProductId, ProductName, CompanyId, CompanyName, feedbackDesc,
		Avg(average) as rating from 
		Temp
		Group By FeedBackCategoryId, CategoryDesc, FeatureID, FeatureName, ProductId, ProductName, CompanyId, CompanyName, feedbackDesc
	)t		
	

	;with cte_Rank (FeedbackCategoryid,featureID, rating,Ranking)
	as (
	select FeedbackCategoryid,featureID,rating,RANK() OVER (
		PARTITION BY FeedbackCategoryid,featureID
		ORDER BY rating asc)
		from #Temp 
	)

	, cte_Avg (FeedbackCategoryid,featureID,ranking,AvgVal)
	as (
	select FeedbackCategoryid,featureID,Max(Ranking),avg(rating) from cte_Rank
	group by FeedbackCategoryid,featureid
	)

	select temp.*, AvgVal from cte_Avg cte
	inner join (
	select FeedbackCategoryid, CategoryDesc, featureID, FeatureName, ProductId, ProductName, CompanyId, CompanyName, feedbackDesc,rating,RANK() OVER (
		PARTITION BY FeedbackCategoryid,featureID
		ORDER BY rating asc) as ranking
		from #Temp ) as temp on cte.featureID = temp.featureID
	and cte.FeedbackCategoryid = temp.FeedbackCategoryid
	and cte.ranking = temp.ranking
	
 Drop table #Temp

 END