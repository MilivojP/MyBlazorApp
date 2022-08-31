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
            var tokenExpiry = DateTime.UtcNow.AddMinutes(10);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IsAdmin.ToString())
                }),
                Expires = tokenExpiry,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new Token { 
                Username = user.UserName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                ExpiresIn = (int)tokenExpiry.Subtract(DateTime.UtcNow).TotalSeconds,
                AccessToken = token 
            };
        }
    }
}
