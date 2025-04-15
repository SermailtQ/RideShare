using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models;

namespace RideShare.DAL.Configuration
{
    internal class UserRoleModelEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.ToTable("UserRoles")
                .HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired().HasMaxLength(20);

            builder.Property(u => u.Description)
                .IsRequired().HasMaxLength(250);
        }
    }
}
