namespace firm_registry_api.Models
{
    public class EntrepreneurRequest : CompanyRequest
    {
        public Founder Owner { get; set; } = new Founder();
    }
}
