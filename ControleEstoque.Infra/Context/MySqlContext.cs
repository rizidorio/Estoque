﻿using ControleEstoque.Domain.Entity;
using ControleEstoque.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Measures> Measures { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<User> User { get; set; }

        public MySqlContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MeasuresConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new StockMovementConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
