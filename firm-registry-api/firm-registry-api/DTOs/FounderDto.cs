namespace firm_registry_api.DTOs
{
    public class FounderDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public AddressDto Address { get; set; } = new AddressDto();
        public decimal? Share { get; set; } 
    }

}
