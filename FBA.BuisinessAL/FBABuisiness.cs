using FBA.DataAL;
using FBA.DataAL.Entity;
using System;
using System.Collections.Generic;

namespace FBA.BuisinessAL
{
    public class FBABuisiness
    {
        FBAData fbaDObj = new FBAData();
        public List<FeedBack> GetFeedBackAnalysis(string conStr)
        {
            return fbaDObj.GetFeedBackAnalysis(conStr);
        }
        public List<Product> GetProductDetails(string conStr)
        {
            return fbaDObj.GetProductDetails(conStr);
        }

        public List<ProductQuestion> GetProductQuestionSList(string conStr, int productId)
        {
            return fbaDObj.GetProductQuestionSList(conStr, productId);
        }

        public bool AddFeedBackAnalysisCategory(string conStr, string text)
        {
            return fbaDObj.AddFeedBackAnalysisCategory(conStr, text);
        }
        public bool AddFeedBackAnalysis(string conStr, FBEntry fbDataObj)
        {

            fbDataObj.FeedBackCategoryId = AnalyseFeedBackCategory(fbDataObj.FeedBackDesc);
            fbDataObj.FeedBackIndex = AnalyseFeedBackSentiment(fbDataObj.FeedBackDesc);
            return fbaDObj.AddFeedBackAnalysis(conStr, fbDataObj);
        }

        private int AnalyseFeedBackCategory(string fbText)
        {
            int id = 0;

            //TO-DO//Need to write Algo to Identify Category of feedback
            if (fbText.Contains("payment"))
            {
                id = 1;
            }
            else if (fbText.Contains("bug"))
            {
                id = 2;
            }
            //
            return id;
        }

        private float AnalyseFeedBackSentiment(string fbText)
        {
            float fbRatio = 0.0F;
            //TO-DO//Need to call analysis Algo to Identify sentiment of feedback
            if (fbText.Contains("good"))
            {
                fbRatio = 1.0F;
            }
            else if (fbText.Contains("bad"))
            {
                fbRatio = 0.1F;
            }
            //
            return fbRatio;
        }
    }
}
