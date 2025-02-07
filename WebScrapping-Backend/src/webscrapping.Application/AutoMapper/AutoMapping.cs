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
        ResponseToEntity();
    }

    private void ScrapToEntity()
    {
        CreateMap<ScrapFood, Food>();
    }

    private void ResponseToEntity()
    {
        CreateMap<ResponseRegisterFoodsJson, Food>();
    }

    private void EntityToResponse()
    {
        CreateMap<Food, ResponseSingleFoodJson>();
        CreateMap<Food, ResponseFoodsJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
        CreateMap<List<Food>, ResponseFoodsJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
        CreateMap<Food, ResponseShortFoodJson>();
    }
}
