using api.Enums;

namespace api.Models
{
    public class Presupuesto
    {
        private Guid Id;
        private Guid ClienteId;
        private int Numero;
        private string Titulo;
        private EstadosPresupuesto Estado;
        private DateOnly FechaEmision;
        private DateOnly ValidoHasta;
        private Monedas Moneda;
        private decimal TarifaHora;
        private decimal Total;
        private decimal AnticipoPorcentaje;
        private decimal? AbonoMensual;
        private string? AbonoIncluye;
        private string? Notas;

    }
}
