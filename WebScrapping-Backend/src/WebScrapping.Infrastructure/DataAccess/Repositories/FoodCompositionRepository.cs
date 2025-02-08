﻿using Microsoft.EntityFrameworkCore;
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

    public async Task AddAll(List<FoodComposition> foodCompositions)
    {
        if (foodCompositions == null || !foodCompositions.Any()) return;

        // Lista de combinações únicas de FoodCode + Componente
        var existingEntries = await _dbContext.FoodComposition
            .Where(fc => foodCompositions.Select(f => f.FoodCode).Contains(fc.FoodCode))
            .Select(fc => new { fc.FoodCode, fc.Component })
            .ToListAsync();

        // Filtra apenas os que ainda não existem no banco
        var newFoodCompositions = foodCompositions
            .Where(f => !existingEntries.Any(e => e.FoodCode == f.FoodCode && e.Component == f.Component))
            .ToList();

        if (newFoodCompositions.Any())
        {
            await _dbContext.FoodComposition.AddRangeAsync(newFoodCompositions);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Food?> GetByCode(string code)
    {
        return await _dbContext.Foods
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Code == code);
    }
}
