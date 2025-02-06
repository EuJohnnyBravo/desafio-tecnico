using WebScrapping.Communication.Requests;
using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.Search;

public class SearchFoodUseCase : ISearchFoodUseCase
{
    public async Task<ResponseSearchFoodJson> Execute(RequestSearchFoodJson request)
    {
        return await Task.FromResult(new ResponseSearchFoodJson());
    }
}
