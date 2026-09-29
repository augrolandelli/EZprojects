using api.Enums;

namespace api.Models
{
    public class Cliente
    {
        private Guid Id;
        private string Nombre;
        private string? Contacto;
        private string? Email;
        private string? Telefono;
        private string? Cuit;
        private string? Rubro;
        private Etapas Etapa;
        private string? Notas;
    }
}
