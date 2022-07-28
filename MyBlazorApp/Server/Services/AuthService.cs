using Microsoft.IdentityModel.Tokens;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBlazorApp.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(DatabaseContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Login(string email, string password)
        {
            if (!_dbContext.Users.Any(x => x.Email == email && x.Password == password))
            {
                throw new Exception("This email address or password is not valid!");
            }

            var user = _dbContext.Users.First(x => x.Email == email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return new Token { AccessToken = tokenHandler.WriteToken(token) };
        }
    }
}
