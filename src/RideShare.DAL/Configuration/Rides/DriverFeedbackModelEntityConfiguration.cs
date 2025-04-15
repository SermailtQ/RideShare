using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class DriverFeedbackModelEntityConfiguration : IEntityTypeConfiguration<DriverFeedbackEntity>
{
    public void Configure(EntityTypeBuilder<DriverFeedbackEntity> builder)
    {
        builder.ToTable("DriverFeedbacks")
            .HasKey(b => b.Id);

        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.BookingId).IsRequired();
        builder.Property(b => b.DriverId).IsRequired();
        builder.Property(b => b.Rating).IsRequired();
        builder.Property(b => b.Comment).HasMaxLength(250);
    }
}
