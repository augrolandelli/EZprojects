namespace api.Models
{
    public class TokenAgente
    {
        private Guid Id;
        private Guid IntegranteId;
        private string Prefijo;
        private string Hash;
        private DateTime? ExpiraEn;
        private DateTime? UltimoUsoEn;
        private DateTime? RevocadoEn;
    }
}
