using Serilog;

namespace WebAPI.Configurations
{
    public static class WebApiServiceExtensions
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            SetupEndpoints(services);
            SetupLogging(services);

            return services;
        }

        private static void SetupEndpoints(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }

        private static void SetupLogging(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog(Log.Logger);
            });
        }
    }
}
