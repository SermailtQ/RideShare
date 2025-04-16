using RideShare.DAL.Models;

namespace RideShare.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<UserRoleEntity> GetByNameAsync(string roleName);
    }
}
