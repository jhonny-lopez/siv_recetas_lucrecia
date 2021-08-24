using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private ITokenService _tokenService;

        public AccountsController(IConfiguration config, ITokenService tokenService)
        {
            _config = config;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel model)
        {
            var issuer = _config["Jwt:Issuer"];
            var signingKey = _config["Jwt:Key"];

            if(model.UserName == "admin" && model.Password == "123456")
            {
                string token = _tokenService.BuildToken(signingKey, issuer,
                    new DTOs.UserDTO()
                    {
                        UserId = Guid.NewGuid().ToString(),
                        Password = string.Empty,
                        UserName= model.UserName,
                        Role = "Admin"
                    });

                return Ok(new
                {
                    token = token
                });
            }

            return Unauthorized();
        }
    }
}
