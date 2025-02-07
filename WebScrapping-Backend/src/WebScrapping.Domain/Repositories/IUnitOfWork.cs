namespace WebScrapping.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
