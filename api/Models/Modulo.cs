using api.Enums;

namespace api.Models
{
    public class Modulo
    {
        private Guid Id;
        private Guid ProyectoId;
        private Guid? PresupuestoItemId;
        private string Nombre;
        private string Descripcion;
        private EstadosModulo Estado;
        private decimal Precio;
        private Guid? AprobadoPorId;
        private DateTime? AprobadoEn;
        private DateTime? EntregadoEn;
        private int Orden;
    }
}
