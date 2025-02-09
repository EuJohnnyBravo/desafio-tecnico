using AutoMapper;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;

namespace WebScrapping.Application.UseCases.Foods.GetByCode;

public class GetFoodByCodeUseCase : IGetFoodByCodeUseCase
{
    private readonly IFoodReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetFoodByCodeUseCase(IFoodReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseSingleFoodJson> Execute(string code)
    {
        var result = await _repository.GetByCode(code);
        return _mapper.Map<ResponseSingleFoodJson>(result);
    }
}
