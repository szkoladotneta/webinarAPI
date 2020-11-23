using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebinarAPI.Domain.Model;
using WebinarAPI.Model;

namespace WebinarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _config = config;

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel loginModel)
        {
            IActionResult response = Unauthorized();
            var success = AuthenticateUser(loginModel);

            if (success)
            {
                var tokenString = GenerateJsonWebToken(loginModel);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJsonWebToken(UserModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(UserModel loginModel)
        {
            var result = _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, lockoutOnFailure: false).Result;

            return result.Succeeded;
        }
    }
}
