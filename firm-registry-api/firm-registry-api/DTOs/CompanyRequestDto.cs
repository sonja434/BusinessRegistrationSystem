using firm_registry_api.Models.Enums;

namespace firm_registry_api.DTOs
{
    public abstract class CompanyRequestDto
    {
        public string CompanyName { get; set; }           
        public string ActivityCode { get; set; }     
        public AddressDto Address { get; set; } = new AddressDto();
        public CompanyType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;              
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<string> Documents { get; set; } = new List<string>();
    }
}
