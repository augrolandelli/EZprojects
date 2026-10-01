using api.Common;
using api.Models;
using api.Tenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Data.Interceptors
{
    public class EspacioInterceptor : SaveChangesInterceptor
    {
        private readonly ITenancyContext _tenancyContext;

        public EspacioInterceptor(ITenancyContext tenancyContext)
        {
            _tenancyContext = tenancyContext;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            AsignarEspacioId(eventData);
            return result;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            AsignarEspacioId(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void AsignarEspacioId(DbContextEventData eventData)
        {
            if (eventData.Context == null) return;
            Guid? espacioActual = _tenancyContext.EspacioId;
            foreach (var e in eventData.Context.ChangeTracker.Entries<IDelEspacio>())
            {
                if (e.State == EntityState.Added)
                {
                    if (espacioActual == null)
                    {
                        if(!eventData.Context.ChangeTracker.Entries<Espacio>().Any(x=>x.State==EntityState.Added && e.Entity.EspacioId == x.Entity.Id))
                        {
                            throw new AppException(403, "No se puede crear un dato sin un espacio activo.");
                        }

                    }
                    else
                    {
                        if(e.Entity.EspacioId == Guid.Empty)
                        {
                            e.Entity.EspacioId = espacioActual.Value;
                            
                        }else if(e.Entity.EspacioId == espacioActual)
                        {

                        }
                        else
                        {
                            throw new AppException(403, "No se puede crear un dato en otro espacio.");
                        }

                    }
                }
                else if (e.State == EntityState.Modified || e.State == EntityState.Deleted)
                {
                    if (espacioActual == null)
                    {
                        throw new AppException(403, "No se puede modificar un dato sin un espacio activo.");
                    }else if (e.Property(x=>x.EspacioId).IsModified) 
                    {
                        throw new AppException(403, "No se puede mover un dato a otro espacio.");
                    }else if (e.Entity.EspacioId != espacioActual)
                    {
                        throw new AppException(403, "No se puede modificar un dato de otro espacio.");
                    }
                    
                }

            }
        }
    }
}
