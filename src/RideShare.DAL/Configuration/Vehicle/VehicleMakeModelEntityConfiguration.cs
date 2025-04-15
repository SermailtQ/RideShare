using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class VehicleMakeModelEntityConfiguration : IEntityTypeConfiguration<VehicleMakeEntity>
{
    public void Configure(EntityTypeBuilder<VehicleMakeEntity> builder)
    {
        builder.ToTable("VehicleMakes")
            .HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(v => v.Models)
            .WithOne(v => v.Make)
            .HasForeignKey(v => v.MakeId)
            .OnDelete(DeleteBehavior.NoAction);
uilder.HasMany(v => v.Models)
            .WithOne(v => v.Make)
            .HasForeignKey(v => v.MakeId)
            .OnDelete(DeleteBehavior.NoAction);

        b
    }
}
