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

    public async Task<List<Food>> GetAll()
    {
        return await _dbContext.Foods.AsNoTracking().ToListAsync();
    }

    public async Task<Food?> GetByCode(string code)
    {
        return await _dbContext.Foods
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Code == code);
    }

    async Task<bool> IFoodReadOnlyRepository.Exists(string code)
    {
        var food = await GetByCode(code);
        return food != null;
    }
}
