using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class BookingModelEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("Bookings")
            .HasKey(b => b.Id);

        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.RideId).IsRequired();
        builder.Property(b => b.TotalPrice)
            .IsRequired()
            .HasPrecision(18, 4);

        builder.HasMany(b => b.DriverFeedbacks)
            .WithOne(p => p.Booking)
            .HasForeignKey(p => p.BookingId)
            .OnDelete(DeleteBehavior.NoAction);  

    }
}
