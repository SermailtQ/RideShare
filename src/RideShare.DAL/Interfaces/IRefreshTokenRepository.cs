using RideShare.DAL.Models.User;

namespace RideShare.DAL.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddUserRefreshTokens(UserRefreshToken refreshToken);

        Task<UserRefreshToken> GetRefreshTokensForUser(string refreshtoken);

        Task RemoveUserRefreshTokens(Guid UserId);
        Task SaveChangesAsync();
    }
}
