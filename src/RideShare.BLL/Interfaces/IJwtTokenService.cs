using RideShare.DAL.Models;

namespace RideShare.BLL.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(UserEntity user);
    string GenerateRefreshToken();
}
