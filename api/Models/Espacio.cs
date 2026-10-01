using api.Enums;

namespace api.Models
{
    public class Espacio : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public Moneda MonedaPorDefecto { get; set; }
        public decimal TarifaHoraArs { get; set; }
        public decimal TarifaHoraUsd { get; set; }
        public decimal AnticipoPorcentaje { get; set; }
        public string? Localidad { get; set; }
        public ICollection<Integrante> Integrantes { get; set; } = new List<Integrante>();
    }
}
