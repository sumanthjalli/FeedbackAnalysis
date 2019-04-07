using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBA.BuisinessAL;
using FBA.DataAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FeedbackAnalysis.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {

        IConfiguration _iconfiguration;
        public ProductsController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        FBABuisiness fbaBObj = new FBABuisiness();

        [HttpGet]
        public IEnumerable<Product> GetProducts(string test = "")
        {
            string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
            return fbaBObj.GetProductDetails(conStr);
        }
    }
}