using EcommerceGate.Core.Data;
using EcommerceGate.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EcommerceGate.Core.Extensions
{

    public class EcommerceGateUserStore : UserStore<User, Role, EcommerceGateDbContext, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>
    {
        public EcommerceGateUserStore(EcommerceGateDbContext context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}
