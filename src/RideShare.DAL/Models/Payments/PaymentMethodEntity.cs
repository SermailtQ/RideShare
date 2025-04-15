namespace RideShare.DAL.Models;

public class PaymentMethodEntity : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<RideEntity>? Rides { get; set; }
}
