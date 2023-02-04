namespace Supermarket.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Data.Contexts;
    using Supermarket.DataTransferModels.Response;
    using Supermarket.Domain.Entities;
    using Constants;

    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PaginatedResult<Category>> GetAsync(
            int limit = 10,
            int offset = 0,
            string name = "")
        {
            var categories = _context.Categories
            .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)));

            int totalCount = categories.Count();

            limit = Math.Min(limit, Constants.MaxLimit);

            var results = await categories.Skip(offset).Take(limit).ToListAsync().ConfigureAwait(false);

            return new PaginatedResult<Category>
            {
                Data = results,
                Limit = limit,
                Offset = offset,
                TotalCount = totalCount
            };
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}

