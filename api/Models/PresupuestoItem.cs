namespace api.Models
{
    public class PresupuestoItem
    {
        private Guid Id;
        private Guid? Presupuestoid;
        private Guid? ModuloCatalogoId;
        private string Nombre;
        private string Descripcion;
        private decimal HorasBackend;
        private decimal HorasFrontend;
        private decimal FactorCOmplejidad;
        private decimal Precio;
        private int Orden;
    }
}
