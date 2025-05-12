using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Data;
using Backend.Application.Interfaces.Repositories;
using Backend.Infrastructure.Repositories;
using Backend.Application.Books.DI;
using Backend.Application.Loan.DI;

namespace Backend.Infrastructure.Configurations
{
    public static class BackendServiceExtensions
    {
        public static IServiceCollection AddBackendServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .AddInfrastructure(configuration)
                .AddApplication(configuration);
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .ConfigureDatabase(configuration)
                .ConfigureRepositories()
                ;
        }

        private static IServiceCollection AddApplication(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .ConfigureUseCases();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services.AddDbContextPool<DataContext>(options =>
            {
                options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("Backend.Infrastructure")
                    );
            });
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<ILoanRepository, LoanRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IReservationRepository, ReservationRepository>()
                ;
        }

        private static IServiceCollection ConfigureUseCases(this IServiceCollection services)
        {
            return services
                .AddBookUseCases()
                .AddLoanUseCases()
                ;
        }
    }
}