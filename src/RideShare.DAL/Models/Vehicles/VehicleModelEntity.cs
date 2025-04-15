namespace RideShare.DAL.Models;

public class VehicleModelEntity : BaseEntity
{
    public required string Name { get; set; } = default!;
    public required int Seats { get; set; }
    public required Guid MakeId { get; set; }

    // Navigation properties
    public required VehicleMakeEntity Make { get; set; }
    public virtual ICollection<VehicleEntity>? Vehicles { get; set; }
}
