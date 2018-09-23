using EcommerceGate.Core.Controllers;
using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Module.Products.Models;

namespace EcommerceGate.Module.Products.Controllers
{

    public class ProductOptionValueDefaultsController : GenericController<ProductOptionValueDefault>
    {
        public ProductOptionValueDefaultsController(IRepository<ProductOptionValueDefault> repo) : base(repo) { }
    }
}
