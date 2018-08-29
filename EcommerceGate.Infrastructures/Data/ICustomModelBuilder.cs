using Microsoft.EntityFrameworkCore;

namespace EcommerceGate.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
