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
    }

    private void EntityToResponse()
    {
        CreateMap<Food, ResponseFoodsJson>();
        CreateMap<Food, ResponseShortFoodJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
        CreateMap<List<Food>, ResponseShortFoodJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
    }
}
