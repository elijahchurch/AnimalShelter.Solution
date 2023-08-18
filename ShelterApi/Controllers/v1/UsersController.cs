using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShelterApi.Controllers.v1
{
    [Route("shelterapi/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShelterApiContext _db;
        private readonly IConfiguration _configuration;
        public UsersController(ShelterApiContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("/getToken")]
        public IActionResult GetToken(User user)
        { 
            IActionResult response = Unauthorized();

            User resultUser = _db.Users
                .FirstOrDefault(entry => entry.UserName == user.UserName && entry.Password == user.Password);

            if(resultUser != null)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    }
                );

                var expires = DateTime.UtcNow.AddMinutes(60);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            return response;
        }

    }
}