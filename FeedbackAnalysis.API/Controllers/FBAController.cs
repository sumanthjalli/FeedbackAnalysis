using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBA.BuisinessAL;
using FBA.DataAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FBAMaster.Controllers
{
    [Route("api/[controller]")]
    public class FBAController : Controller
    {
        IConfiguration _iconfiguration;
        public FBAController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        FBABuisiness fbaBObj = new FBABuisiness();
        // GET api/values
        [HttpGet]
        public IEnumerable<FeedBack> Get()
        {
            string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
            return fbaBObj.GetFeedBackAnalysis(conStr);
        }

        #region Unused sample
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/values/5
        //[HttpGet("{text}")]
        //public bool Get(string text)
        //{
        //    string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
        //    return fbaBObj.AddFeedBackAnalysisCategory(conStr, text);
        //}
        #endregion

        // POST api/values
        [HttpPost]
        public bool Post(FBEntry fbDataObj)
        {
            string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
            return fbaBObj.AddFeedBackAnalysis(conStr, fbDataObj);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
