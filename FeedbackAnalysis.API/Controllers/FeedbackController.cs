﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBA.BuisinessAL;
using FBA.DataAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FeedbackAnalysis.API.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {

        IConfiguration _iconfiguration;
        public FeedbackController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        FBABuisiness fbaBObj = new FBABuisiness();

        [HttpPost]
        [Route("SaveFeedback")]
        public async System.Threading.Tasks.Task<bool> SaveFeedback(List<FeedBack> feedbacks)
        {
          string conStr = _iconfiguration.GetValue<string>("FBASetting:ConnectionString");
          return  await fbaBObj.SaveFeedbackDetailsAsync(feedbacks, conStr);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
