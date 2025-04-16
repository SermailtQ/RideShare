using Microsoft.Extensions.DependencyInjection;
using RideShare.BLL.Interfaces;
using RideShare.BLL.Services;

namespace RideShare.BLL
{
    public static class ServicesBuilderBLL
    {
        public static void RegisterServicesBLL(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
        }
    }
}
