using EcommerceGate.Infrastructures.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EcommerceGate.Core.Models
{
    public class Role : IdentityRole<int>, IEntityWithTypedId<int>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
