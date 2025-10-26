namespace firm_registry_api.Models
{
    public class LimitedCompanyRequest : CompanyRequest
    {
        public string DirectorFullName { get; set; }
        public decimal ShareCapital { get; set; }
        public List<Founder> Founders { get; set; } = new List<Founder>();
    }
}
