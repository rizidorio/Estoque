using ControleEstoque.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ControleEstoque.Infra.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.SKU).IsUnique();
            builder.Property(p => p.SKU).HasMaxLength(12).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Cust).HasColumnType("decimal(15,2)");
            builder.Property(p => p.Quantity).HasColumnType("decimal(10,2)");
            builder.Property(p => p.ChangeDate).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Inactive).HasDefaultValue(false);
        }
    }
}
