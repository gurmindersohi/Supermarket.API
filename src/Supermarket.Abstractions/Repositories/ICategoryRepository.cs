namespace Supermarket.Abstractions.Repositories
{
    using System;
    using Supermarket.DataTransferModels.Response;
    using Supermarket.Domain.Entities;

    public interface ICategoryRepository
	{
        Task<PaginatedResult<Category>> GetAsync(
            int limit = 10,
            int offset = 0,
            string name = "");

        Task AddAsync(Category category);

        Task<Category> FindByIdAsync(int id);

        void Update(Category category);

        void Remove(Category category);
    }
}

