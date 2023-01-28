namespace Supermarket.Abstractions.Repositories
{
    using System;
    using Supermarket.Domain.Entities;

    public interface ICategoryRepository
	{
        Task<IEnumerable<Category>> ListAsync();

        Task AddAsync(Category category);

        Task<Category> FindByIdAsync(int id);

        void Update(Category category);

        void Remove(Category category);
    }
}

