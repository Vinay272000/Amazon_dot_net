using AmazonClone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AmazonClone.Context
{
    public class AmazonDbContext: DbContext
    {
        public AmazonDbContext(DbContextOptions<AmazonDbContext> options): base(options)
        {

        }

        public DbSet<Category>? categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(o => new { o.Id, o.CategoryId });
           
        }
    }
}
