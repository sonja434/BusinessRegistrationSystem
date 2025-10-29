namespace firm_registry_api.Models
{
    public class LimitedPartner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public Address Address { get; set; }
        public decimal? Share { get; set; }
        public int LimitedPartnershipRequestId { get; set; }
        public LimitedPartnershipRequest LimitedPartnershipRequest { get; set; }
    }
}
