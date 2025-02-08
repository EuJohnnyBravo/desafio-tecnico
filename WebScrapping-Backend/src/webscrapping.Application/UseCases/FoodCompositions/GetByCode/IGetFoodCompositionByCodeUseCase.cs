using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.FoodCompositions.GetByCode;

public interface IGetFoodCompositionByCodeUseCase
{
    Task<ResponseGetAllFoodCompositionByCodeJson> Execute(string code);
}
