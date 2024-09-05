using core.Models;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Concrete;

namespace MyGalaxy_Auction.Extensions
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services , IConfiguration configuration)
        {
            #region
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IBidService, BidService>();

            // มั่นใจว่าจะมีการสร้างอินสแตนซ์ใหม่สำหรับการร้องขอแต่ละครั้ง
            services.AddScoped(typeof(ApiResponse));
            #endregion

            return services;
        }
    }
}
