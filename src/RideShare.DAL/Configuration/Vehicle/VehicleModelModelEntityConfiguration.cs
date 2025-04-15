using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class VehicleModelModelEntityConfiguration : IEntityTypeConfiguration<VehicleModelEntity>
{
    public void Configure(EntityTypeBuilder<VehicleModelEntity> builder)
    {
        builder.ToTable("VehicleModels")
            .HasKey(v => v.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Seats)
            .IsRequired();

        builder.HasMany(u => u.Vehicles)
            .WithOne(u => u.Model)
            .HasForeignKey(u => u.ModelId);
    }
}
