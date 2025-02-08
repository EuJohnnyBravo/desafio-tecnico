using AutoMapper;
using WebScrapping.Communication.DataScrap;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        ScrapToEntity();
        EntityToResponse();
    }

    private void ScrapToEntity()
    {
        CreateMap<ScrapFood, Food>();
        CreateMap<ScrapFoodComposition, FoodComposition>();
    }

    private void EntityToResponse()
    {
        CreateMap<Food, ResponseSingleFoodJson>();
        CreateMap<List<Food>, ResponseGetAllFoodJson>();
        CreateMap<FoodComposition, ResponseFoodCompositionJson>();
        CreateMap<List<FoodComposition>, ResponseGetAllFoodCompositionByCodeJson>()
            .ForMember(dest => dest.Compositions, opt => opt.MapFrom(src => src));
    }
}
