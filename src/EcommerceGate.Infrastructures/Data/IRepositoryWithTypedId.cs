using EcommerceGate.Infrastructures.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceGate.Infrastructures.Data
{
    public interface IRepositoryWithTypedId<T, TId> where T : IEntityWithTypedId<TId>
    {
        T GetById(TId id);

        IQueryable<T> Query();

        void Add(T entity);

        void SaveChanges();

        Task SaveChangesAsync();

        void Remove(T entity);
    }
}

