using EcommerceGate.Core.Data;
using EcommerceGate.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EcommerceGate.Core.Extensions
{

    public class EcommerceGateRoleStore : RoleStore<Role, EcommerceGateDbContext, int, UserRole, IdentityRoleClaim<int>>
    {
        public EcommerceGateRoleStore(EcommerceGateDbContext context) : base(context)
        {
        }
    }
}
