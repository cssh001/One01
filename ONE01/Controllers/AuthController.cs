using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ONE01.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        
        public ActionResult<User> Register(User request)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Username = request.Username;
            user.Password = password;

            return Ok(user);

        }

        [HttpPost("login")]

        public ActionResult<User> Login(User request)
        {
            if(user.Username != request.Username)
            {
                return BadRequest("user not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong password");
            };
            string password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Username = request.Username;
            user.Password = password;

            string token = CreateToken(user);
            return Ok(token);

        }

        private string CreateToken (User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my secred key"));
            
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
            
            var token =new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        


    }
}
