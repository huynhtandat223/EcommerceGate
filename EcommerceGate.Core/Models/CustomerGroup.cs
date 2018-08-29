using System;
using System.Collections.Generic;

namespace EcommerceGate.Core.Models
{
    public class CustomerGroup : EntityBase
    {
        public CustomerGroup()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public IList<CustomerGroupUser> Users { get; set; } = new List<CustomerGroupUser>();
    }
}
