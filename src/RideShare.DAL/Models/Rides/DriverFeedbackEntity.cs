namespace RideShare.DAL.Models;

public class DriverFeedbackEntity : BaseEntity
{
    public required Guid UserId { get; set; }
    public required Guid BookingId { get; set; }
    public required Guid DriverId { get; set; }
    public required int Rating { get; set; }
    public string? Comment { get; set; }


    // Navigation properties
    public required virtual UserEntity User { get; set; }
    public required virtual BookingEntity? Booking { get; set; }
    public required virtual UserEntity Driver { get; set; }
}
