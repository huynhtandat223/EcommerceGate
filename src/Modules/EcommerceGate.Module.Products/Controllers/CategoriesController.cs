using EcommerceGate.Core.Controllers;
using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Module.Products.Models;

namespace EcommerceGate.Module.Products.Controllers
{
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IRepository<Category> repo) : base(repo)
        {
        }
    }
}
