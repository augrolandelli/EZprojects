namespace api.Tenancy
{
    public interface ITenancyContext
    {
        Guid? EspacioId { get; }
        Guid? IntegranteId { get; }
    }
}
