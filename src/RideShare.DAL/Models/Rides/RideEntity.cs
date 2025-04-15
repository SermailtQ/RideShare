namespace RideShare.DAL.Models;

public class RideEntity : BaseEntity
{
    public required Guid VehicleId { get; set; }
    public required DateTime DepartureDate { get; set; } = DateTime.UtcNow;
    public required string DepartureAdress { get; set; }
    public required string DestinationAdress { get; set; }
    public required bool Baggage { get; set; }
    public required Decimal Price { get; set; }
    public required Guid PaymentMethodId { get; set; }
    public string? Notes { get; set; }

    // Navigation properties

    public virtual required VehicleEntity Vehicle { get; set; }
    public virtual required PaymentMethodEntity PaymentMethod { get; set; }
    public virtual ICollection<BookingEntity>? Bookings { get; set; }
}
