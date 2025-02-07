using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Repositories;
using WebScrapping.Domain.Repositories.Foods;
using WebScrapping.Infrastructure.DataAccess;
using WebScrapping.Infrastructure.DataAccess.Repositories;

namespace WebScrapping.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        AddRepositories(services);
        AddDbContext(services, config);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFoodCompositionReadOnlyRepository, FoodCompositionRepository>();
        services.AddScoped<IFoodCompositionWriteOnlyRepository, FoodCompositionRepository>();
        services.AddScoped<IFoodReadOnlyRepository, FoodRepository>();
        services.AddScoped<IFoodWriteOnlyRepository, FoodRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Connection");
        services.AddDbContext<WebScrappingDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}
