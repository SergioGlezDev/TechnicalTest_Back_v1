using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TecnicalTest_Back;

namespace HomeForGuest_Back.Controllers
{
    /*
    [Route("api/usuario")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;

        public LogInController(ApplicationContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        [Route("LogIn")]
        public dynamic LogIn([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.username.ToString();
            string pass = data.password.ToString();

            User userFound = _context.Users.FirstOrDefault(x => x.Username == user && x.Password == pass);
            if (userFound == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales Incorrectas",
                    result = ""
                };
            }

            var jwt = _config.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("username", userFound.Username), 
                new Claim("email", userFound.Email),
                new Claim("role", userFound.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                signingCredentials: signIn
                );
            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)

            };
        }
    }
    */
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IAuthorization _authorization;

        public LogInController(IAuthorization authorization)
        {
            _authorization = authorization;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User authorization)
        {
            var authorization_result = await _authorization.ReturnToken(authorization);
            if (authorization_result == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(authorization_result);
            }
        }
    }
}
