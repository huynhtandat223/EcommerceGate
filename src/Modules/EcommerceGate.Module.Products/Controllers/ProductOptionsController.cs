using EcommerceGate.Core.Controllers;
using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Module.Products.Models;

namespace EcommerceGate.Module.Products.Controllers
{
    public class ProductOptionsController : GenericController<ProductOption>
    {
        public ProductOptionsController(IRepository<ProductOption> repo): base(repo) { }
    }
}
