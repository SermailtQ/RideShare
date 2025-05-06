namespace RideShare.DAL.Models.User
{
    public class UserRefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime ExpiresOnUtc { get; set; } = DateTime.UtcNow.AddDays(7);

        public required virtual UserEntity User { get; set; }
    }
}
