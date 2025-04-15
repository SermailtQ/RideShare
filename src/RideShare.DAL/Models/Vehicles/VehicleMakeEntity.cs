namespace RideShare.DAL.Models;

public class VehicleMakeEntity : BaseEntity
{
    public required string Name { get; set; }
    public virtual ICollection<VehicleModelEntity>? Models { get; set; }
}
