namespace Supermarket.Data.Repositories
{
    using Supermarket.Data.Contexts;

    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

