using Microsoft.AspNet.OData.Builder;

namespace EcommerceGate.Core
{
    public interface IODataCustomModelBuilder
    {
        void RegistEntities(ODataModelBuilder builder);
    }
}
