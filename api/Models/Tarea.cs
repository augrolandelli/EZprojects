using api.Enums;

namespace api.Models
{
    public class Tarea
    {
        private Guid Id;
        private Guid ModuloId;
        private PartesTarea Parte;
        private string Titulo;
        private string Descripcion;
        private Guid? AsignadoId;
        private EstadosTarea Estado;
        private decimal? HorasEstimadas;
        private int Orden;
    }
}
