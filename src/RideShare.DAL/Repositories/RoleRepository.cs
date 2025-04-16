using Microsoft.EntityFrameworkCore;
using RideShare.DAL.Context;
using RideShare.DAL.Interfaces;
using RideShare.DAL.Models;

namespace RideShare.DAL.Repositories
{
    internal class RoleRepository(AppDbContext _context) : IRoleRepository
    {
        public async Task<UserRoleEntity> GetByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName) ?? throw new ArgumentNullException();
        }
    }
}
