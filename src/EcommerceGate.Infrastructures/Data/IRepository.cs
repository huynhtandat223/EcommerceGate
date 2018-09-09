using EcommerceGate.Infrastructures.Models;

namespace EcommerceGate.Infrastructures.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, int> where T : IEntityWithTypedId<int>
    {
    }
}
