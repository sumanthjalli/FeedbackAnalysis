using FBA.DataAL;
using FBA.DataAL.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

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

        public async System.Threading.Tasks.Task<bool> SaveFeedbackDetailsAsync(IList<FeedBack> feedback,string ConStr)
        {
            foreach (var item in feedback)
            {
                if (item.FeedBackCategoryId == 6)
                {
                    ApiResponse apiResponse = new ApiResponse();
                    var client = new HttpClient();
                    var queryString = HttpUtility.ParseQueryString(string.Empty);

                    // This app ID is for a public sample app that recognizes requests to turn on and turn off lights
                    var luisAppId = "cb041e70-b76b-4dcb-ba94-b6802dbe0d92";
                    var endpointKey = "4429d8a6623b45a5b04cfb36742bc354";

                    // The request header contains your subscription key
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", endpointKey);

                    // The "q" parameter contains the utterance to send to LUIS
                    queryString["q"] = "product is good";

                    // These optional request parameters are set to their default values
                    queryString["timezoneOffset"] = "0";
                    queryString["verbose"] = "false";
                    queryString["spellCheck"] = "false";
                    queryString["staging"] = "false";

                    var endpointUri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + luisAppId + "?" + queryString;
                    //var endpointUri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/cb041e70-b76b-4dcb-ba94-b6802dbe0d92?verbose=true&timezoneOffset=-360&subscription-key=4429d8a6623b45a5b04cfb36742bc354&q=Its%20good%20all";
                    var response = await client.GetAsync(endpointUri);

                    //var strResponseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse1 = await response.Content.ReadAsStringAsync();

                    var data = (JObject)JsonConvert.DeserializeObject(apiResponse1);
                    //JObject json = JObject.Parse(apiResponse1.ToString());

                    string FeedBackDesc = data["query"].Value<string>();
                    //string sentimentAnalysis = data["label"].Value<string>();
                    //string rssTitles = (string)json["sentimentAnalysis"]["label"];
                    string rssTitle = data["sentimentAnalysis"]["label"].Value<string>();
                    string topScoringIntent = data["topScoringIntent"]["intent"].Value<string>();
                    int FeedBackCategoryId;
                    switch (topScoringIntent.ToLower())
                    {
                        case "ease of use":
                            FeedBackCategoryId = 1;
                            break;
                        case "product requirements":
                            FeedBackCategoryId = 2;
                            break;
                        case "quality of support":
                            FeedBackCategoryId = 3;
                            break;
                        case "additional features needed":
                            FeedBackCategoryId = 4;
                            break;
                        case "suggestions":
                            FeedBackCategoryId = 5;
                            break;
                        default:
                            FeedBackCategoryId = 6;
                            break;
                    }
                    fbaDObj.SaveFeedback(FeedBackCategoryId, item.ProductId, item.ProductId, FeedBackDesc, item.FeedBackIndex, ConStr);                  
                }
                else
                {
                    fbaDObj.SaveFeedback(item.FeedBackCategoryId, item.ProductId, item.ProductId, item.FeedBackDesc, item.FeedBackIndex, ConStr);
                }
            }

            return true;
        }

        public List<ProductQuestion> GetProductQuestionSList(string conStr, int productId)
        {
            return fbaDObj.GetProductQuestionSList(conStr, productId);
        }
        

        public bool AddFeedBackAnalysisCategory(string conStr,string text)

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
