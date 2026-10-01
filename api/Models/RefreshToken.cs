namespace api.Models
{
    public class RefreshToken : EntidadBase
    {
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public string Hash { get; set; } = string.Empty;
        public DateTime ExpiraEn { get; set; }
        public DateTime? RevocadoEn { get; set; }
        public Guid? ReemplazadoPorId { get; set; }
    
    }
}
