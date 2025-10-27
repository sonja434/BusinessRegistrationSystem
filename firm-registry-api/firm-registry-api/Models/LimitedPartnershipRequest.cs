namespace firm_registry_api.Models
{
    public class LimitedPartnershipRequest : CompanyRequest
    {
        public List<Founder> GeneralPartners { get; set; } = new List<Founder>();
        public List<Founder> LimitedPartners { get; set; } = new List<Founder>();
    }
}
