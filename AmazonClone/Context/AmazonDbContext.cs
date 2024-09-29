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
        public DbSet<Products>? products { get; set; } 
        public DbSet<Countrys>? countrys { get; set; }
        public DbSet<States>? States { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(o => new { o.Id, o.CategoryId });

            modelBuilder.Entity<Products>()
            .HasKey(p => new { p.ProductId, p.ImageId });

        }
    }
}
