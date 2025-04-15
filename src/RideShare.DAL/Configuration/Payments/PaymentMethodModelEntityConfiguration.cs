using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration;

internal class PaymentMethodModelEntityConfiguration : IEntityTypeConfiguration<PaymentMethodEntity>
{
    public void Configure(EntityTypeBuilder<PaymentMethodEntity> builder)
    {
        builder.ToTable("PaymentMethods").HasKey(x => x.Id);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasMany(x => x.Rides)
            .WithOne(x => x.PaymentMethod)
            .HasForeignKey(x => x.PaymentMethodId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}