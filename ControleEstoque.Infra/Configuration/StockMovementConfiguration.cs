using ControleEstoque.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ControleEstoque.Infra.Configuration
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.HasKey(sm => sm.Id);
            builder.Property(sm => sm.Quantity).HasColumnType("decimal(10,2)");
            builder.Property(sm => sm.DateMovement).HasDefaultValue(DateTime.Now);
        }
    }
}
