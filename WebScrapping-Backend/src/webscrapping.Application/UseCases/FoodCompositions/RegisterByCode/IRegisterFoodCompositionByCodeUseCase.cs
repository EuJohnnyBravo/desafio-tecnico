using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.FoodCompositions.RegisterByCode;

public interface IRegisterFoodCompositionByCodeUseCase
{
    Task<ResponseRegisterFoodCompositionJson> Execute(string code);
}
