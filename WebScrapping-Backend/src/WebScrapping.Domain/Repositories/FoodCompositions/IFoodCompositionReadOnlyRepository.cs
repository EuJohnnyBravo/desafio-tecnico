using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.DataAccess.Repositories;

public interface IFoodCompositionReadOnlyRepository
{
    Task<List<FoodComposition>> GetByCode(string code);
}