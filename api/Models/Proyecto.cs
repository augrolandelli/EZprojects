using api.Enums;

namespace api.Models
{
    public class Proyecto
    {
        private Guid Id;
        private Guid ClienteId;
        private Guid? PresupuestoId;
        private string Nombre;
        private string Descripcion;
        private EstadosProyecto Estado;
        private DateOnly? FechaInicio;
        private DateOnly? FechaEstimadaFin;
        private Monedas Moneda;
        private string? RepoUrl;
        private string? DeployUrl;
        private string? StagingUrl;
        private string? SwaggerUrl;
    }
}
