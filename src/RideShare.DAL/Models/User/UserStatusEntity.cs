namespace RideShare.DAL.Models
{
    public class UserStatusEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required virtual ICollection<UserEntity> Users { get; set; }
    }
}
