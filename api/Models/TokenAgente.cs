namespace api.Models
{
    public class TokenAgente : EntidadBase, IDelEspacio
    {
        public Guid IntegranteId { get; set; }
        public Integrante Integrante { get; set; } = null!;
        public string Prefijo { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
        public DateTime? ExpiraEn { get; set; }
        public DateTime? RevocadoEn { get; set; }
        public DateTime? UltimoUsoEn { get; set; }
        public Guid EspacioId { get; set; }
        public Espacio Espacio { get; set; } = null!;
    }
}
