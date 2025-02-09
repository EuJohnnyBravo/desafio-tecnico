using Microsoft.Extensions.DependencyInjection;
using WebScrapping.Application.AutoMapper;
using WebScrapping.Application.UseCases.FoodCompositions.GetByCode;
using WebScrapping.Application.UseCases.FoodCompositions.RegisterByCode;
using WebScrapping.Application.UseCases.Foods.GetAll;
using WebScrapping.Application.UseCases.Foods.GetByCode;
using WebScrapping.Application.UseCases.Foods.Scrap;
namespace WebScrapping.Application;

public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IScrapFoodsUseCase, ScrapFoodsUseCase>();
        services.AddScoped<IGetAllFoodsUseCase, GetAllFoodsUseCase>();
        services.AddScoped<IGetFoodByCodeUseCase, GetFoodByCodeUseCase>();
        services.AddScoped<IGetFoodCompositionByCodeUseCase, GetFoodCompositionByCodeUseCase>();
        services.AddScoped<IRegisterFoodCompositionByCodeUseCase, RegisterFoodCompositionByCodeUseCase>();
    }
}
