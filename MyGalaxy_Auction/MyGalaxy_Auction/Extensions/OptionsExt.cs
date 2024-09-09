using MyGalaxy_Auction.Common;

namespace MyGalaxy_Auction.Extensions
{
    public static class OptionsExt
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StripeSettings>(options => configuration.GetSection("StripeSettings").Bind(options));
            return services;
        }
    }
}
