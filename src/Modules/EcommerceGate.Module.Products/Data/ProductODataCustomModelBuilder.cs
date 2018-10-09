using EcommerceGate.Core;
using EcommerceGate.Core.Dto.Products;
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
            builder.EntitySet<Product>("Products");

            builder.Namespace = "CategoryService";
            builder.EntityType<Category>().Collection
                .Function("Grouped")
                .ReturnsCollection<CategoryDto>();

        }

    }
}
