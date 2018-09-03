using EcommerceGate.Core.Entities;
using System;

namespace EcommerceGate.Core.Models
{
    public class UserAddress : EntityBase
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTimeOffset? LastUsedOn { get; set; }
    }
}
