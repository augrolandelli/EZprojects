using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Data.Interceptors
{
    public class FechasInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            ActualizarFechas(eventData);
            return result;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            ActualizarFechas(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void ActualizarFechas(DbContextEventData eventData)
        {
            if (eventData.Context == null) return;
            DateTime now = DateTime.UtcNow;
            foreach (var e in eventData.Context.ChangeTracker.Entries<EntidadBase>())
            {
                if (e.State == EntityState.Added)
                {
                    e.Entity.CreadoEn = now;
                    e.Entity.ActualizadoEn = now;
                }else if(e.State == EntityState.Modified)
                {
                    e.Entity.ActualizadoEn = now;
                    e.Property(x => x.CreadoEn).IsModified = false;
                }

            }
        }
    }
}
