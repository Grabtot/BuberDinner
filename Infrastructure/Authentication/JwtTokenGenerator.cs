using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            SigningCredentials singingCredentials = new(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-meeeeeeeeeeeeeeeega-secret-key")),
                SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new(
               issuer: "BuberDinner",
               expires: DateTime.Now.AddDays(1),
               claims: claims,
               signingCredentials: singingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

