using data_access.Context;
using data_access.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyGalaxy_Auction.Extensions
{
    public static class PersistenceExtensionLayer
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {

            #region Context
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            return services;

        }
    }
}
