using System;
using System.Collections.Generic;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Enums;
using AquadisF1.Model.Models;
using AquadisF1.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AquadisF1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAccountLogic _accountLogic;
        
        public ValuesController(Factory.Factory factory)
        {
            _accountLogic = factory.GetAccountLogic(Engine.Memory);
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<object> Get()
        {
            var test = BaseResponse.SuccessResponse("yo", new {name = "test", kek = "zzzz"}, 200);
            return new JsonResult(test).Value;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] User user)
        {
            if (_accountLogic.Create(user))
            {
                return "jeej";
            }

            return "kankermongool";
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