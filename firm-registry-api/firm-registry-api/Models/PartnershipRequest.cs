namespace firm_registry_api.Models
{
    public class PartnershipRequest : CompanyRequest
    {
        public List<Founder> Partners { get; set; } = new List<Founder>();
    }
}
