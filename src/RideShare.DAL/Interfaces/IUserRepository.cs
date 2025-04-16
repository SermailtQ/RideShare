using System.Linq.Expressions;
using RideShare.DAL.Models;

namespace RideShare.DAL.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(UserEntity user);
    void UpdateUserAsync(UserEntity user);
    Task<UserEntity?> GetUserByCriteriaAsync(Expression<Func<UserEntity, bool>> expression);
    Task<bool> IsEmailInUseAsync(string email);
    Task<bool> IsUsernameInUseAsync(string username);
    Task<bool> IsPhoneInUseAsync(string phone);
    Task<bool> SaveChangesAsync();
}
