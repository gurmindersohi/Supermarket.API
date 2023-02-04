namespace Supermarket.Data.Contexts
{
    using Supermarket.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
                (
                new Category { Id = 101, Name = "Diary" },
                new Category { Id = 102, Name = "Deli" },
                new Category { Id = 103, Name = "Electronics" },
                new Category { Id = 104, Name = "Fashion" },
                new Category { Id = 105, Name = "Home goods" },
                new Category { Id = 106, Name = "Beauty" },
                new Category { Id = 107, Name = "Sports and outdoors" },
                new Category { Id = 108, Name = "Food and grocery" },
                new Category { Id = 109, Name = "Health and wellness" },
                new Category { Id = 110, Name = "Toys and games" },
                new Category { Id = 111, Name = "Automotive" },
                new Category { Id = 112, Name = "Books and media" },
                new Category { Id = 113, Name = "Fruits and Vegetables" }
                );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuatityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

        }
    }
}

