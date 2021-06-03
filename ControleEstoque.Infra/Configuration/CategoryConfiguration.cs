using ControleEstoque.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Code).IsUnique();
            builder.Property(c => c.Code).HasMaxLength(7).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Inactive).HasDefaultValue(false);

            builder.HasMany(c => c.Products).WithOne(p => p.Caterory);
        }
    }
}
