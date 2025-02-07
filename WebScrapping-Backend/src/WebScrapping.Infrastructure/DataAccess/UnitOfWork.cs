using WebScrapping.Domain.Repositories;

namespace WebScrapping.Infrastructure.DataAccess;

internal class UnitOfWork: IUnitOfWork
{
    private readonly WebScrappingDbContext _dbContext;
    public UnitOfWork(WebScrappingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
