using RideShare.BLL.Dtos.Account;

namespace RideShare.BLL.Interfaces;
public interface IAccountService
{
    Task RegisterUserAsync(RegisterUserDto entity);
    Task<string> LoginUserAsync(UserLoginDto entity);
}
