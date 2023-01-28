namespace Supermarket.Abstractions.Repositories
{
    using Supermarket.Domain.Entities;

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        
        Task<Category> GetByIdAsync(int id);

        Task<bool> AddAsync(Category category);

        Task<bool> UpdateAsync(Category category);

        Task<bool> DeleteAsync(Category category);
    }
}

