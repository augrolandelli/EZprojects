using api.Enums;

namespace api.Models
{
    public class Pago
    {
        private Guid Id;
        private Guid ClienteId;
        private Guid? ProyectoId;
        private DateOnly Fecha;
        private decimal Monto;
        private Monedas Moneda;

        private MetodosPago MetodoPago;
        private string? Referencia;
    }
}
