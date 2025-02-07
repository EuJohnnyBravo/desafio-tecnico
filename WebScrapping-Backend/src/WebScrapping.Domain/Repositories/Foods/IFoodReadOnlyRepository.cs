using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.DataAccess.Repositories;

public interface IFoodReadOnlyRepository
{
    Task<List<Food>> GetAll();
    Task<Food?> GetByCode(string code);
}
