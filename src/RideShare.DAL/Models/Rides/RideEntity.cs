namespace RideShare.DAL.Models.Rides
{
    public class RideEntity : BaseEntity
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DepartureDate { get; set; } = DateTime.UtcNow;
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string Notes { get; set; }

        // Navigation properties

        public virtual required UserEntity Driver { get; set; }
        public virtual required VehicleEntity Vehicle { get; set; }

    }
}
