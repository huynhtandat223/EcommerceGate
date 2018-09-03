namespace EcommerceGate.Core.Models
{
    public class District : EntityBase
    {
        public District() { }

        public District(int id)
        {
            Id = id;
        }

        public long StateOrProvinceId { get; set; }

        public virtual StateOrProvince StateOrProvince { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}
