using Microsoft.EntityFrameworkCore;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Infrastructure.DataAccess;

public class WebScrappingDbContext : DbContext
{
    public WebScrappingDbContext(DbContextOptions<WebScrappingDbContext> options) : base(options){}

    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<FoodComposition> FoodComposition { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>().HasKey(f => f.Code);
    }
}
