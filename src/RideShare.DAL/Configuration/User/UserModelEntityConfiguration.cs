using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration
{
    internal class UserModelEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);

            builder.Property(u => u.Firstname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Lastname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Birthdate)
                .IsRequired();

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(50);

            #region Relationships

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity("RoleClaims");

            builder.HasMany(u => u.Vehicles)
                .WithOne(v => v.Driver)
                .HasForeignKey(v => v.DriverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.DriverFeedbacks)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
