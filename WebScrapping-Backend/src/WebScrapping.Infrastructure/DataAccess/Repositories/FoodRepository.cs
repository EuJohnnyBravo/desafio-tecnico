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

    public async Task AddAll(List<Food> foods)
    {
        var existingFoods = await _dbContext.Foods.AsNoTracking()
            .Where(f => foods.Select(food => food.Code).Contains(f.Code))
            .Select(f => f.Code)
            .ToListAsync();

        var foodsToAdd = foods.Where(food => !existingFoods.Contains(food.Code)).ToList();

        if(foodsToAdd.Any())
        {
            await _dbContext.Foods.AddRangeAsync(foodsToAdd);
            await _dbContext.SaveChangesAsync();
        }
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
