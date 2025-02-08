using AutoMapper;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;

namespace WebScrapping.Application.UseCases.FoodComposition.RegisterByCode;

public class RegisterFoodCompositionByCodeUseCase : IRegisterFoodCompositionByCodeUseCase
{
    private readonly IFoodCompositionWriteOnlyRepository _repositoryWrite;
    private readonly IMapper _mapper;
    public RegisterFoodCompositionByCodeUseCase(
        IFoodCompositionWriteOnlyRepository repositoryWrite,
        IMapper mapper)
    {
        _repositoryWrite = repositoryWrite;
        _mapper = mapper;
    }

    public Task<ResponseRegisterFoodCompositionJson> Execute(string code)
    {
        throw new NotImplementedException();
    }

    //public async Task<ResponseRegisterFoodCompositionJson> Execute(string code)
    //{
    //    var entity = _mapper.Map<FoodComposition>(code);
    //}
}
