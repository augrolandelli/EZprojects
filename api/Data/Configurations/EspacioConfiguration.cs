using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class EspacioConfiguration : IEntityTypeConfiguration<Espacio>
    {
        public void Configure(EntityTypeBuilder<Espacio> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100);
            builder.Property(x => x.Slug).HasMaxLength(100);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.MonedaPorDefecto).HasMaxLength(10).HasConversion<string>();
            builder.Property(x => x.TarifaHoraArs).HasPrecision(12, 2);
            builder.Property(x => x.TarifaHoraUsd).HasPrecision(12, 2);
            builder.Property(x => x.AnticipoPorcentaje).HasPrecision(5, 2);
            builder.Property(x => x.Localidad).HasMaxLength(100);
        }
    }
}
