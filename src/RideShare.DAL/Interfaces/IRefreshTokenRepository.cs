using RideShare.DAL.Models.User;

namespace RideShare.DAL.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddUserRefreshTokens(UserRefreshToken refreshToken);

        Task<UserRefreshToken> GetSavedRefreshTokens(string email, string refreshtoken);

        Task DeleteUserRefreshTokens(string email, string refreshToken);
        Task SaveChangesAsync();
    }
}
