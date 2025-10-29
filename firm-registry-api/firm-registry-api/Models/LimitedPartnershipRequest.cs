namespace firm_registry_api.Models
{
    public class LimitedPartnershipRequest : CompanyRequest
    {
        public List<GeneralPartner> GeneralPartners { get; set; } = new List<GeneralPartner>();
        public List<LimitedPartner> LimitedPartners { get; set; } = new List<LimitedPartner>();
    }
}
