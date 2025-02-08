using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Foods.Scrap;

public interface IScrapFoodsUseCase
{
    Task<ResponseRegisterFoodsJson> Execute();
}


