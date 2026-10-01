using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class IntegranteConfiguration : IEntityTypeConfiguration<Integrante>
    {
        public void Configure(EntityTypeBuilder<Integrante> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100);
            builder.Property(x => x.Tipo).HasMaxLength(20).HasConversion<string>();
            builder.Property(x => x.Rol).HasMaxLength(20).HasConversion<string>();
            builder.HasIndex(x => new { x.EspacioId, x.UsuarioId }).IsUnique();
            builder.HasOne(x => x.Espacio).WithMany(i => i.Integrantes).HasForeignKey(x => x.EspacioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Usuario).WithMany(u => u.Integrantes).HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
