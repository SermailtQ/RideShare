using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration.Rides
{
    internal class RideModelEntityConfiguration : IEntityTypeConfiguration<RideEntity>
    {
        public void Configure(EntityTypeBuilder<RideEntity> builder)
        {
            builder.ToTable("Rides")
                .HasKey(r => r.Id); 

            builder.Property(r => r.DepartureAdress)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(r => r.DestinationAdress)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(r => r.Baggage)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired()
                .HasPrecision(18, 4);

            builder.Property(r => r.PaymentMethodId)
                .IsRequired();

            builder.Property(r => r.Notes)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(builder => builder.Bookings)
                .WithOne(p => p.Ride)
                .HasForeignKey(p => p.RideId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
