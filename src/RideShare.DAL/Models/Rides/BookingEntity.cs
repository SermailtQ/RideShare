namespace RideShare.DAL.Models;

public class BookingEntity : BaseEntity
{
    public required Guid UserId { get; set; }
    public required Guid RideId { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual required UserEntity User { get; set; }
    public virtual ICollection<DriverFeedbackEntity>? DriverFeedbacks { get; set; }
    public virtual required RideEntity Ride { get; set; }
}
