using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.Repositories.Foods;

public interface IFoodWriteOnlyRepository
{
    Task Add(Food food);
}
