namespace RideShare.DAL.Models;

public class UserEntity : BaseEntity
{
    // Identity
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    // Personal Info
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Phone { get; set; }
    public string? PhotoUrl { get; set; }

    // Status
    public DateTime LastLogin { get; set; } = DateTime.UtcNow;
    public bool Activated { get; set; } = false;  // Email verified
    public bool Verified { get; set; } = false;   // Personal Info verified

    // Navigation properties
    public virtual ICollection<UserEntity>? Users { get; set; }
    public virtual ICollection<VehicleEntity>? Vehicles { get; set; }

}
