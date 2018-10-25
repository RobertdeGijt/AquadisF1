using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Enums;
using AquadisF1.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AquadisF1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountLogic _accountLogic;
        
        public AccountController(Factory.Factory factory)
        {
            _accountLogic = factory.GetAccountLogic(Engine.Memory);
        }

        [HttpPost("login")]
        public ActionResult<JsonResult> Login([FromBody] AquadisF1.DTO.Account.Login user)
        {
            if (!_accountLogic.Login(user.Email, user.Password)) return new JsonResult("ur login info is not valid.");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SADFSDAFDKj23j32jh423@#KROROKKO@#FKO@#KRO@#KOR#@OKP$OPK#@");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JsonResult(token);


        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            bool kek = _accountLogic.Create(new User
            {
                Email = "kejejejejje"
            });
            
            Console.WriteLine("test");

            return new JsonResult(new User
            {
                Id = 1,
                Email = "kektus",
                Password = "eeeee"
            });
        }
        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] AquadisF1.DTO.Account.Create user)
        {
            User newUser = new User
            {
                Email = user.Email,
                Password = user.Password
            };

            if (_accountLogic.Create(newUser))
            {
                return "jeej";
            }

            return "Error ActionResult";
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            User user = _accountLogic.Read(id);
            if (user == null)
            {
                return "Error ActionResult";
            }

            return user.Password;
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