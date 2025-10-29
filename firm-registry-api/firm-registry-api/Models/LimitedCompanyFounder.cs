namespace firm_registry_api.Models
{
    public class LimitedCompanyFounder
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public Address Address { get; set; }
        public decimal? Share { get; set; }
        public int LimitedCompanyRequestId { get; set; }
        public LimitedCompanyRequest LimitedCompanyRequest { get; set; }
    }
}
