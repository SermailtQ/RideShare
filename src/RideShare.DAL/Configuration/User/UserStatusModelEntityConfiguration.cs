using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration
{
    internal class UserStatusModelEntityConfiguration : IEntityTypeConfiguration<UserStatusEntity>
    {
        public void Configure(EntityTypeBuilder<UserStatusEntity> builder)
        {
            builder.ToTable("UserStatus")
                .HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired().HasMaxLength(20);

            builder.HasMany(u => u.Users)
                .WithOne(s => s.Status)
                .HasForeignKey(u => u.StatusId);
        }
    }
}
