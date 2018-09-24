using EcommerceGate.Core.Controllers;
using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Module.Products.Models;

namespace EcommerceGate.Module.Products.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IRepository<Product> repo) : base(repo)
        {

        }
    }
}
