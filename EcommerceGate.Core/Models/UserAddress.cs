using EcommerceGate.Core.Entities;
using System;

namespace EcommerceGate.Core.Models
{
    public class UserAddress : EntityBase
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTimeOffset? LastUsedOn { get; set; }
    }
}
