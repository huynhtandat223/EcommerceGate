using EcommerceGate.Core.Models;

namespace EcommerceGate.Module.Products.Models
{
    public class ProductOptionValueDefault : EntityBase
    {
        public ProductOption Option { set; get; }
        public int OptionId { set; get; }
        public string Value { set; get; }
        public int SortOrder { set; get; }
    }
}
