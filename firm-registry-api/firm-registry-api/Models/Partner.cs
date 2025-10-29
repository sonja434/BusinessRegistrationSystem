namespace firm_registry_api.Models
{
    namespace firm_registry_api.Models
    {
        public class Partner
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string JMBG { get; set; }
            public Address Address { get; set; }
            public decimal? Share { get; set; }
            public int PartnershipRequestId { get; set; }
            public PartnershipRequest PartnershipRequest { get; set; }
        }
    }
}
