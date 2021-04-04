using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.ViewModel;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Common
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("userregistration")]
        public async Task<IActionResult> UserRegistration([FromBody] UserEmployerRegistrationBodyModel userRegistrationBodyModel)
        {
            try
            {
                var data = await _userService.UserRegistration(userRegistrationBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@userRegistrationBodyModel} on {UserRegistration}", userRegistrationBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("userlogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginBodyModel userLoginBodyModel)
        {
            try
            {
                var data = await _userService.UserLogin(userLoginBodyModel);

                if (data != null)
                {
                    var tokenString = GenerateJSONWebToken(data);
                    data.Token = tokenString;
                }
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@userLoginBodyModel} on {UserLogin}", userLoginBodyModel, DateTime.Now);
                throw exception;
            }
        }

        private string GenerateJSONWebToken(UserLoginViewModel userLoginViewModel)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,userLoginViewModel.LoginId),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role,userLoginViewModel.UserType),
                };



                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(600),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
