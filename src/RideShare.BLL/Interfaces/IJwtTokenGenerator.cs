using RideShare.DAL.Models;

namespace RideShare.BLL.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserEntity user);
}
