using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class VehicleModelEntityConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {

        builder.ToTable("Vehicles")
            .HasKey(v => v.Id);

        builder.Property(u => u.LicensePlate)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(u => u.Color)
            .IsRequired();

        builder.HasMany(v => v.Rides)
            .WithOne(r => r.Vehicle)
            .HasForeignKey(r => r.VehicleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
