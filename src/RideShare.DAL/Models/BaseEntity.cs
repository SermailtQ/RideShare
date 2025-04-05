namespace RideShare.DAL.Models;

public abstract class BaseEntity
{
    public required Guid Id { get; set; } = Guid.NewGuid();
}
