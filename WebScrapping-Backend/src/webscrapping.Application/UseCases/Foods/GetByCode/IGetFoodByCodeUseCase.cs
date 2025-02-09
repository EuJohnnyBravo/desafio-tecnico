using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Foods.GetByCode;

public interface IGetFoodByCodeUseCase
{
    Task<ResponseSingleFoodJson> Execute(string code);
}
