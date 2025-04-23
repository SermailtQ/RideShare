using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RideShare.BLL.Interfaces;
using RideShare.DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace RideShare.BLL.Services
{
    internal sealed class JwtTokenService(IConfiguration _configuration) : IJwtTokenService
    {
        public string GenerateToken(UserEntity entity)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256Signature
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: GetClaims(entity),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private List<Claim> GetClaims(UserEntity entity)
        {
            return new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, entity.Email),
            new (JwtRegisteredClaimNames.Name, entity.Username),
        };
        }
    }
}
