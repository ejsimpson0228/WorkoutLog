using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WorkoutLog.API.Models;
using WorkoutLog.API.Models.Auth;

namespace WorkoutLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public UserController(UserManager<IdentityUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [HttpOptions]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            var applicationUser = new IdentityUser()
            {
                UserName = model.Username.ToLower(),
                Email = model.Email.ToLower()
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: log exceptions
                return BadRequest(new { message = "Something went wrong. Please try again later." });
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username.ToLower());

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserId", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddHours(3),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    return BadRequest(new { message = "Username or password is incorrect." });
            }
            catch (Exception ex)
            {
                // TODO: log exceptions
                return BadRequest(new { message = "Something went wrong. Please try again later." });
            }

        }
    }
}