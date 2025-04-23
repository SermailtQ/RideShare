namespace RideShare.DAL.Models.User
{
    public class UserRefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;

        public required virtual UserEntity User { get; set; }
    }
}
