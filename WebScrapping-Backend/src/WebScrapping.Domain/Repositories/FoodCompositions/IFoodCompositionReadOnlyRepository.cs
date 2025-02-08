using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.DataAccess.Repositories;

public interface IFoodCompositionReadOnlyRepository
{
    Task<Food?> GetByCode(string code);
}