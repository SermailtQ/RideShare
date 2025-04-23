using Microsoft.EntityFrameworkCore;
using RideShare.DAL.Configuration;
using RideShare.DAL.Configuration.Rides;
using RideShare.DAL.Configuration.User;
using RideShare.DAL.Models;
using RideShare.DAL.Models.User;

namespace RideShare.DAL.Context
{
    public class AppDbContext : DbContext
    {

        #region Constructors
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base (options)
        {
        }

        #endregion

        #region Setters For Entities
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> Roles { get; set; }
        public DbSet<UserStatusEntity> UserStatus { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<DriverFeedbackEntity> DriverFeedbacks { get; set; }

        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
        public DbSet<VehicleMakeEntity> Makes { get; set; }

        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<RideEntity> Rides { get; set; }
        public DbSet<PaymentMethodEntity> paymentMethods { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // [User] [Role] [Status] [RefreshTokens]
            builder.ApplyConfiguration(new UserModelEntityConfiguration());
            builder.ApplyConfiguration(new UserRoleModelEntityConfiguration());
            builder.ApplyConfiguration(new UserStatusModelEntityConfiguration());
            builder.ApplyConfiguration(new UserRefreshTokensModelEntityConfiguration());

            // [Vehicle] [Model] [Make]
            builder.ApplyConfiguration(new VehicleModelEntityConfiguration());
            builder.ApplyConfiguration(new VehicleModelModelEntityConfiguration());
            builder.ApplyConfiguration(new VehicleMakeModelEntityConfiguration());

            // [Booking] [Feedback] [Ride]
            builder.ApplyConfiguration(new BookingModelEntityConfiguration());
            builder.ApplyConfiguration(new DriverFeedbackModelEntityConfiguration());
            builder.ApplyConfiguration(new RideModelEntityConfiguration());

            // [Payment]
            builder.ApplyConfiguration(new BookingModelEntityConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
