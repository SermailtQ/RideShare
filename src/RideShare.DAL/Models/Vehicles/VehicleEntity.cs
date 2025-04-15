using System.Drawing;

namespace RideShare.DAL.Models;

public class VehicleEntity : BaseEntity
{
    public required Guid DriverId { get; set; }
    public required Guid ModelId { get; set; }
    public required string LicensePlate { get; set; }
    public required Color Color { get; set; }

    // Navigation properties
    public required virtual UserEntity? Driver { get; set; }
    public required virtual VehicleModelEntity? Model { get; set; }
    public required virtual ICollection<RideEntity>? Rides { get; set; } = new List<RideEntity>();

}
