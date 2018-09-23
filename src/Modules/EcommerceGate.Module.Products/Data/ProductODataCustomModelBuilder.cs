using EcommerceGate.Core;
using EcommerceGate.Module.Products.Models;
using Microsoft.AspNet.OData.Builder;

namespace EcommerceGate.Module.Products.Data
{
    public class ProductODataCustomModelBuilder : IODataCustomModelBuilder
    {
        public void RegistEntities(ODataModelBuilder builder)
        {
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<ProductOption>("ProductOptions");
            builder.EntitySet<ProductOptionValueDefault>("ProductOptionValueDefaults");
        }

    }
}
