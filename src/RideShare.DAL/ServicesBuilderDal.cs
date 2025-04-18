﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideShare.DAL.Context;

namespace RideShare.DAL
{
    public static class ServicesBuilderDal
    {
        public static void RegisterServicesDal(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
