using RideShare.BLL.Interfaces;
using RideShare.DAL.Models;

namespace RideShare.BLL.Services
{
    internal class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(UserEntity user)
        {
            return string.Empty;
        }
    }
}
