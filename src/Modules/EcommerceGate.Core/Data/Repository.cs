using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Infrastructures.Models;

namespace EcommerceGate.Core.Data
{
    public class Repository<T> : RepositoryWithTypedId<T, int>, IRepository<T>
       where T : class, IEntityWithTypedId<int>
    {
        public Repository(EcommerceGateDbContext context) : base(context)
        {
        }
    }
}
