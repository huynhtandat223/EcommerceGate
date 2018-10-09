using System.Collections.Generic;

namespace EcommerceGate.Core.Dto.Products
{
    public class CategoryDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int ParentId { set; get; }
        public string SKUPrefix { set; get; }
        public string ParentId_Id { set; get; }
        public IEnumerable<CategoryDto> Children { set; get; }
    }
}
