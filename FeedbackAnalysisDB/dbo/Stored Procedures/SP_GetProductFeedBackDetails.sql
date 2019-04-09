
-- Exec SP_GetProductFeedBackDetails

CREATE Procedure [dbo].[SP_GetProductFeedBackDetails]
As
Begin

	;with Temp As
	(
		select FeedBackCategoryId, FC.CategoryDesc, feedbackId, feedbackDesc, F.FeatureID, Fet.FeatureName ,feedbackindex, starrating, 
		avg((feedbackindex+starrating)/2) as average 
		from FeedBack F
		Left Join FeedbackCategory FC ON FC.CategoryID = F.FeedBackCategoryId
		Left Join Feature Fet ON Fet.FeatureId = F.FeatureID
		Group By FeedBackCategoryId, FC.CategoryDesc, feedbackId, feedbackDesc, F.FeatureID, Fet.FeatureName ,feedbackindex, starrating
	)
	
	Select * into #Temp 
	from 
	(
		select FeedBackCategoryId, CategoryDesc, FeatureID, FeatureName, feedbackDesc,
		Avg(average) as rating from 
		Temp
		Group By FeedBackCategoryId, CategoryDesc, FeatureID, FeatureName, feedbackDesc
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
	select FeedbackCategoryid, CategoryDesc, featureID, FeatureName, feedbackDesc,rating,RANK() OVER (
		PARTITION BY FeedbackCategoryid,featureID
		ORDER BY rating asc) as ranking
		from #Temp ) as temp on cte.featureID = temp.featureID
	and cte.FeedbackCategoryid = temp.FeedbackCategoryid
	and cte.ranking = temp.ranking
	
 Drop table #Temp

 END