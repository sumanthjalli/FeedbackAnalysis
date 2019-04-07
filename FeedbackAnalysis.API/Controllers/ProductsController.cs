using System.Collections.Generic;
using FBA.BuisinessAL;
using FBA.DataAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FeedbackAnalysis.API.Controllers
{
    [Produces("application/json")]    
    public class ProductsController : Controller
    {

        IConfiguration _iconfiguration;
        public ProductsController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        FBABuisiness fbaBObj = new FBABuisiness();

        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
            return fbaBObj.GetProductDetails(conStr);
        }

        [HttpGet]
        [Route("GetProductQuestions")]
        public IEnumerable<ProductQuestion> GetProductQuestions(int productId=0)
        {
            string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
            return fbaBObj.GetProductQuestionSList(conStr, productId);
        }
    }
}