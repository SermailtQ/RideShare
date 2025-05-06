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

        public async Task<UserRefreshToken> GetRefreshTokensForUser(string refreshToken)
         => await _context.UserRefreshTokens.
                Include(refresh => refresh.User).
            FirstOrDefaultAsync(refresh => refresh.RefreshToken == refreshToken);

        public async Task RemoveUserRefreshTokens(Guid UserId)
        {
            await _context.UserRefreshTokens
                .Where(refresh => refresh.UserId == UserId)
                .ExecuteDeleteAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
