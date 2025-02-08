﻿using AutoMapper;
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
        CreateMap<Food, ResponseFoodsJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
        CreateMap<List<Food>, ResponseFoodsJson>()
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src));
        CreateMap<Food, ResponseShortFoodJson>();
        CreateMap<FoodComposition, ResponseRegisterFoodCompositionJson>();
    }
}
