using System.Security.Claims;

namespace api.Tenancy
{
    public class TenancyContext : ITenancyContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Guid? EspacioId => ObtenerGuidDelClaim("espacio_id");

        public Guid? IntegranteId => ObtenerGuidDelClaim("integrante_id");


        public TenancyContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid? ObtenerGuidDelClaim(string claim)
        {
            if(Guid.TryParse( _httpContextAccessor.HttpContext?.User?.FindFirstValue(claim), out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
            
        }

        
    }
}
