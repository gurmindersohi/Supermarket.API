namespace Supermarket.Data.Repositories
{
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Data.Contexts;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

