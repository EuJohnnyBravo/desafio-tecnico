
using AutoMapper;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;

namespace WebScrapping.Application.UseCases.Food.GetAll;

public class GetAllFoodsUseCase : IGetAllFoodsUseCase
{
    private readonly IFoodReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllFoodsUseCase(
        IFoodReadOnlyRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseFoodsJson> Execute()
    {
        var result = await _repository.GetAll();
        var mappedResult = _mapper.Map<List<ResponseSingleFoodJson>>(result);
        return new ResponseFoodsJson { Foods = mappedResult };
    }
}
