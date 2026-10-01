using api.Enums;

namespace api.Models
{
    public class Integrante : EntidadBase, IDelEspacio
    {
        public TipoIntegrante Tipo { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Rol Rol { get; set; }
        public bool Activo { get; set; } = true;
        public Guid EspacioId { get; set; }
        public Espacio Espacio { get; set; } = null!;
    }
}
