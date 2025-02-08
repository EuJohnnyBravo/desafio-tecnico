using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Foods.GetAll;

public interface IGetAllFoodsUseCase
{
    Task<ResponseGetAllFoodJson> Execute();
}
