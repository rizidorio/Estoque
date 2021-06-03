using ControleEstoque.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Configuration
{
    public class MeasuresConfiguration : IEntityTypeConfiguration<Measures>
    {
        public void Configure(EntityTypeBuilder<Measures> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Code).IsUnique();
            builder.Property(m => m.Code).HasMaxLength(7).IsRequired();
            builder.Property(m => m.Name).HasMaxLength(20).IsRequired();
            builder.Property(m => m.Inactive).HasDefaultValue(false);
            builder.HasMany(m => m.Products).WithOne(p => p.Measure);
        }
    }
}
