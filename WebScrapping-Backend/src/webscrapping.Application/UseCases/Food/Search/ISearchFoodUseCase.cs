using WebScrapping.Communication.Requests;
using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.Search;

public interface ISearchFoodUseCase
{
    Task<ResponseSearchFoodJson> Execute(RequestSearchFoodJson request);
}


