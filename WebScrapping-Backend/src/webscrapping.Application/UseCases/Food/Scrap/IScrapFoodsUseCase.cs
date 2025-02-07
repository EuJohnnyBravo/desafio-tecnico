using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.Scrap;

public interface IScrapFoodsUseCase
{
    Task<ResponseRegisterFoodsJson> Execute();
}


