namespace EcommerceGate.Infrastructures.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
