using Microsoft.EntityFrameworkCore;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Infrastructure.DataAccess;

public class WebScrappingDbContext : DbContext
{
    private DbContextOptions<WebScrappingDbContext> _options;

    public WebScrappingDbContext(DbContextOptions<WebScrappingDbContext> options) : base(options)
    {
        _options = options;
    }

    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<FoodComposition> FoodComposition { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>().HasKey(f => f.Code);
    }
}
