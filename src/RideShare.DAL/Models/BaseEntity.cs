namespace RideShare.DAL.Models;

public abstract class BaseEntity
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
