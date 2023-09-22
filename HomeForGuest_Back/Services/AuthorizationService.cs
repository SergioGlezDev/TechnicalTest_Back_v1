using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TecnicalTest_Back;

namespace HomeForGuest_Back.Services
{
    public class AuthorizationService : IAuthorization
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        private string TokenGenerator(string idUser, List<string> roles)
        {
            var key = _configuration.GetValue<string>("Jwt:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

            
            foreach (var role in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreate = tokenHandler.WriteToken(tokenConfig);

            return tokenCreate;
        }
        public AuthorizationService(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
       public async Task<UserResponse> ReturnToken(User authorization)
       {
            var user = _context.Users.FirstOrDefault(x =>
            x.Username == authorization.Username &&
            x.Password == authorization.Password
    );

    if (user == null)
    {
        return await Task.FromResult<UserResponse>(null);
    }

    // Obtén los roles del usuario (esto depende de cómo estén almacenados los roles en tu sistema)
    var roles = _context.UserRoles
        .Where(ur => ur.UserId == user.Id)
        .Select(ur => ur.Role.Name)
        .ToList();

    string tokenCreate = TokenGenerator(user.Id.ToString(), roles);

    return new UserResponse() { Token = tokenCreate, Result = true, Message = "Generated Token" };
}

    }
}
