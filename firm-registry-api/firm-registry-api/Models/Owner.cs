namespace firm_registry_api.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public Address Address { get; set; }
        public int EntrepreneurRequestId { get; set; }
        public EntrepreneurRequest EntrepreneurRequest { get; set; }
    }
}
