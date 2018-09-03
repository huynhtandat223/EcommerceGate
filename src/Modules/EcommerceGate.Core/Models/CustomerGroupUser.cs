namespace EcommerceGate.Core.Models
{
    public class CustomerGroupUser
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int CustomerGroupId { get; set; }

        public CustomerGroup CustomerGroup { get; set; }
    }
}
