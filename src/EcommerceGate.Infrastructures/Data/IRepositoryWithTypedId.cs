using EcommerceGate.Infrastructures.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceGate.Infrastructures.Data
{
    public interface IRepositoryWithTypedId<T, TId> where T : IEntityWithTypedId<TId>
    {
        T GetById(TId id);
        IQueryable<T> Query();
        T Add(T entity);
        T Remove(T entity);
        T Update(T entity);
    }
}

