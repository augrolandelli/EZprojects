using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class TokenAgenteConfiguration : IEntityTypeConfiguration<TokenAgente>
    {
        public void Configure(EntityTypeBuilder<TokenAgente> builder)
        {
            builder.Property(x => x.Prefijo).HasMaxLength(16);
            builder.Property(x => x.Hash).HasMaxLength(64);
            builder.HasIndex(x => x.Hash).IsUnique();
            builder.HasOne(x => x.Integrante).WithMany().HasForeignKey(x => x.IntegranteId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Espacio).WithMany().HasForeignKey(x => x.EspacioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
