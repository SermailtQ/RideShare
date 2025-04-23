using Microsoft.EntityFrameworkCore;
using RideShare.DAL.Context;
using RideShare.DAL.Interfaces;
using RideShare.DAL.Models.User;

namespace RideShare.DAL.Repositories
{
    internal class RefreshTokenRepository(AppDbContext _context) : IRefreshTokenRepository
    {
        public async Task AddUserRefreshTokens(UserRefreshToken refreshToken)
        {
           await _context.UserRefreshTokens.AddAsync(refreshToken);
        }

        public async Task DeleteUserRefreshTokens(string email, string refreshToken)
        {
            var item = await _context.UserRefreshTokens.FirstOrDefaultAsync(x => x.User.Email == email && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _context.UserRefreshTokens.Remove(item);
            }

            throw new ArgumentNullException(nameof(item), "Refresh token not found");
        }

        public async Task<UserRefreshToken> GetSavedRefreshTokens(string email, string refreshToken) 
            => await _context.UserRefreshTokens.FirstOrDefaultAsync(x => x.User.Email == email && x.RefreshToken == refreshToken);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
