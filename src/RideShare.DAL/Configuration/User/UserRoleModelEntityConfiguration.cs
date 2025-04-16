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

            builder.HasData(
                new UserRoleEntity
                {
                    Id = RolesSeedConstants.AdminRoleId,
                    Name = RolesSeedConstants.AdminRoleName,
                    Description = "Administrator with full access",
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRoleEntity
                {
                    Id = RolesSeedConstants.DriverRoleId,
                    Name = RolesSeedConstants.DriverRoleName,
                    Description = "User who can offer rides",
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRoleEntity
                {
                    Id = RolesSeedConstants.PassagerRoleId,
                    Name = RolesSeedConstants.PassagerRoleName,
                    Description = "Passager who can book rides",
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                });
        }
    }
}
