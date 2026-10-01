using api.Models;
using api.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ITenancyContext _tenancyContext;
        public AppDbContext(DbContextOptions<AppDbContext> options, ITenancyContext tenancyContext) : base(options) { 
            _tenancyContext = tenancyContext;
        }

        public Guid? EspacioIdActual => _tenancyContext.EspacioId;

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Integrante> Integrantes => Set<Integrante>();
        public DbSet<Espacio> Espacios => Set<Espacio>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<TokenAgente> TokensAgente => Set<TokenAgente>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //toda entidad q implemente idelespacio debe estar aca, sino sus datos les aparecen a todos los espacios
            AplicarFiltroDeEspacioId<Integrante>(modelBuilder);
            AplicarFiltroDeEspacioId<TokenAgente>(modelBuilder);
        }

        private void AplicarFiltroDeEspacioId<T>(ModelBuilder modelBuilder) where T : class, IDelEspacio
        {
            modelBuilder.Entity<T>().HasQueryFilter(e => e.EspacioId == EspacioIdActual);
        }

    }
}
