namespace Harvesit.AdministratorServices.Core.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Harvesit.AdministratorServices.Core.Infrastructure.Database;
using Harvesit.AdministratorServices.Core.Infrastructure.Database.Repositories;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Harvesit.AdministratorServices.Infrastructure"));
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<ICropCatalogItemRepository, CropCatalogItemRepository>();

        return services;
    }
}