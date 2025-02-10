using AutoMapper;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Exception;
using WebScrapping.Exception.ExceptionsBase;

namespace WebScrapping.Application.UseCases.FoodCompositions.GetByCode;

public class GetFoodCompositionByCodeUseCase : IGetFoodCompositionByCodeUseCase
{
    private readonly IFoodCompositionReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetFoodCompositionByCodeUseCase(
        IFoodCompositionReadOnlyRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseGetAllFoodCompositionByCodeJson> Execute(string code)
    {
        var result = await _repository.GetByCode(code);
        return _mapper.Map<ResponseGetAllFoodCompositionByCodeJson>(result);
    }
}
