namespace EcommerceGate.Core.Dto.Products
{
    public class CategoryDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int ParentId { set; get; }
        public string SKUPrefix { set; get; }
        public string ParentName { set; get; }
    }
}
