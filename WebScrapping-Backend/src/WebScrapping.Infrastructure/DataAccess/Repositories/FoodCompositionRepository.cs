using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Infrastructure.DataAccess.Repositories;

internal class FoodCompositionRepository : IFoodCompositionWriteOnlyRepository, IFoodCompositionReadOnlyRepository
{
    public Task Add(Food food)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Food>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Food?> GetById(long id)
    {
        throw new NotImplementedException();
    }
}
