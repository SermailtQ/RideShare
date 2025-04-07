namespace RideShare.DAL.Models.Rides
{
    public class Booking : BaseEntity
    {
        public int UserId { get; set; }
        public int RideId { get; set; }

        public int Seats { get; set; } = 1;
    }
}
