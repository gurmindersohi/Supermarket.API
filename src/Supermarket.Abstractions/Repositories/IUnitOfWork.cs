namespace Supermarket.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}

