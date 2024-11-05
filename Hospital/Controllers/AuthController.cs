using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(HospitalDbContext context, IConfiguration configuration) : ControllerBase
    {


        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id },user);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)        
        {
            
            var loginuser = context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            
            if(loginuser == null)
            {
                return Unauthorized();
            }

            return Ok(GenerateJwtToken(user.Username));

        }
        private string GenerateJwtToken(string uname)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.NameIdentifier, uname) },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
                
        }
    }
}
