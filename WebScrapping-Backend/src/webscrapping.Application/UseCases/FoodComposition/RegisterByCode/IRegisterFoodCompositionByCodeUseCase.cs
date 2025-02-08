using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.FoodComposition.RegisterByCode;

public interface IRegisterFoodCompositionByCodeUseCase
{
    Task<ResponseRegisterFoodCompositionJson> Execute(string code);
}
