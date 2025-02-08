using Microsoft.EntityFrameworkCore;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Infrastructure.DataAccess.Repositories;

internal class FoodCompositionRepository : IFoodCompositionWriteOnlyRepository, IFoodCompositionReadOnlyRepository
{
    private readonly WebScrappingDbContext _dbContext;
    public FoodCompositionRepository(WebScrappingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(FoodComposition foodComposition)
    {
        await _dbContext.FoodComposition.AddAsync(foodComposition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Food?> GetByCode(string code)
    {
        return await _dbContext.Foods
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Code == code);
    }
}
