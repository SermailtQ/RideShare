namespace RideShare.DAL.Models;

public class VehicleEntity : BaseEntity
{
    public int DriverId { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public required string Color { get; set; }
    public required string LicensePlate { get; set; }
    public int Seats { get; set; } = 4;

    // Navigation properties
    public UserEntity? Driver { get; set; }
}
