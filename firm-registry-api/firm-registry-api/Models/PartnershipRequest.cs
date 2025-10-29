using firm_registry_api.Models.firm_registry_api.Models;

namespace firm_registry_api.Models
{
    public class PartnershipRequest : CompanyRequest
    {
        public List<Partner> Partners { get; set; } = new List<Partner>();
    }
}
