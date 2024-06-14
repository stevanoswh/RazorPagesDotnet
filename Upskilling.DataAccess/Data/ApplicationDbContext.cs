using Microsoft.EntityFrameworkCore;
using Upskilling.Models;

namespace Upskilling.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Metal", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Punk", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Pop", DisplayOrder = 3 },
                    new Category { Id = 4, Name = "Indie", DisplayOrder = 4 }
                );
        }
    }
}
