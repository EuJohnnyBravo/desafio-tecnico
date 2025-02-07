using WebScrapping.Domain.Entities;

namespace WebScrapping.Domain.Repositories.Foods;

public interface IFoodWriteOnlyRepository
{
    Task Add(Food food);

    /// <summary>
    /// This funtion returns a boolean value indicating if the expense was deleted or not.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
