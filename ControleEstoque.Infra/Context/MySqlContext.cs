using ControleEstoque.Domain.Entity;
using ControleEstoque.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<User> User { get; set; }

        public MySqlContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockMovementConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
