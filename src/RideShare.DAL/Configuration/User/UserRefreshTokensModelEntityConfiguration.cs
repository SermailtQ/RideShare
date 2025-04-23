using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.DAL.Models.User;

namespace RideShare.DAL.Configuration.User
{
    internal class UserRefreshTokensModelEntityConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.ToTable("UserRefreshTokens")
                .HasKey(urt => urt.Id);

            builder.Property(urt => urt.RefreshToken)
                .IsRequired();
        }
    }
}
