namespace api.Models
{
    public class Auditoria
    {
        private Guid Id;
        private Guid IntegranteId;
        private string Accion;
        private string Entidad;
        private Guid EntidadId;
        private DateOnly Fecha;
    }
}
