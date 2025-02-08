using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.DataAccess.Repositories;

public interface IFoodCompositionWriteOnlyRepository
{
    Task Add(FoodComposition foodComposition);
}
