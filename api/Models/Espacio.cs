using api.Enums;

namespace api.Models
{
    public class Espacio
    {
        private int Id;
        private string Nombre;
        private string Slug;
        private Monedas MonedaPorDefecto;
        private decimal TarifaHoraArs;
        private decimal TarifaHoraUsd;
        private decimal AnticipoPorcentaje;
        private string? Localidad;
    }
}
