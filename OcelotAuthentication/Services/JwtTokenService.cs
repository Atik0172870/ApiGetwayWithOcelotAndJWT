using OcelotAuthentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtConfiguration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace OcelotAuthentication.Services
{
    public class JwtTokenService: IJwtTokenService
    {
        private readonly List<User> _users = new()
        {
            new(){ UserName = "admin",
                Password = "admin123",
                Role = "Admin",
                Scopes = new[] { "Add", "Update", "Delete" }
            },
             new(){ UserName = "admin",
                Password = "admin123",
                Role = "Admin",
                Scopes = new[] { "Add", "Update", "Delete" }
            }

        };

        public AuthToken GenereateAuthToken(LoginModel loginModel)
        {
            var user =_users.FirstOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password);
            if (user is null)
                return new AuthToken(Token:string.Empty,Expiry: 0);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(5);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("Role", user.Role),
                new Claim("scope", string.Join(",",user.Scopes))
            };
            var tokenOptions = new JwtSecurityToken(
                issuer: JwtExtensions.ValidIssuer,
                audience: JwtExtensions.ValidIssuer,
                claims: claims,
                expires: expiry,
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthToken(Token: tokenString, Expiry: (int)expiry.Subtract(DateTime.Now).TotalSeconds);


        }
    }
}
