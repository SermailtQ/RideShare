using RideShare.BLL.Dtos.Account;

namespace RideShare.BLL.Interfaces;
public interface IAccountService
{
    Task RegisterUserAsync(RegisterUserDto entity);
    Task<JwtTokenDto> LoginUserAsync(UserLoginDto entity);
    Task<JwtTokenDto> RefreshToken(string refreshToken);
}
