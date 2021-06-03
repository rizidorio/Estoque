using ControleEstoque.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Code).IsUnique();
            builder.Property(u => u.Code).HasMaxLength(7).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(255).IsRequired();
        }
    }
}
