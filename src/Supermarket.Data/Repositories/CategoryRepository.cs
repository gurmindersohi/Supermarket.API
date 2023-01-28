namespace Supermarket.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Data.Contexts;
    using Supermarket.Domain.Entities;

    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
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

