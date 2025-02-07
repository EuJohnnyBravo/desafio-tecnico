using Microsoft.EntityFrameworkCore;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Entities;
using WebScrapping.Domain.Repositories.Foods;

namespace WebScrapping.Infrastructure.DataAccess.Repositories;

internal class FoodRepository : IFoodWriteOnlyRepository, IFoodReadOnlyRepository
{
    private readonly WebScrappingDbContext _dbContext;
    public FoodRepository(WebScrappingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Food food)
    {
        await _dbContext.Foods.AddAsync(food);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> Delete(long id)
    {
        //TODO: Implement this method
        throw new NotImplementedException();
    }

    public Task<List<Food>> GetAll()
    {
        //TODO: Implement this method
        throw new NotImplementedException();
    }

    public async Task<Food?> GetByCode(string code)
    {
        return await _dbContext.Foods
            .AsNoTracking()  // <- Isso impede que o EF Core rastreie a entidade
            .FirstOrDefaultAsync(f => f.Code == code);
    }
}
