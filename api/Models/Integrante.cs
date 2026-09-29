using api.Enums;

namespace api.Models
{
    public class Integrante
    {
        private int Id;
        private TipoIntegrante Tipo;
        private Guid? UsuarioId;
        private string Nombre;
        private Roles Rol;
        private bool Activo;
    }
}
