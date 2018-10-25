using System;
using System.Collections.Generic;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Enums;
using AquadisF1.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquadisF1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRankingLogic _rankingLogic;
        
        public RankingController(Factory.Factory factory)
        {
            _rankingLogic = factory.GetRankingLogic(Engine.Memory);
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "";
        }
        // POST api/values
        [HttpPost]
        public ActionResult<object> Post()
        {
            var kek = new User {Email = "ZZ", Password = "wqerweqr", Id = 1};
            return new ActionResult<object>(new { message = "lev", kek});
           // return BaseResponse.SuccessResponse("liev", new User{Email = "REEEE", Password = "REEEEEE"});
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}