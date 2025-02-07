using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.Scrap;

public interface ISearchFoodUseCase
{
    Task<ResponseShortFoodJson> Execute();
}


