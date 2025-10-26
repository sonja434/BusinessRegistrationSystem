using firm_registry_api.Models.Enums;

namespace firm_registry_api.DTOs
{
    public abstract class CompanyRequestResponseDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int ActivityCodeId { get; set; }
        public AddressDto Address { get; set; } = new AddressDto();
        public CompanyType Type { get; set; }
        public List<string> Documents { get; set; } = new List<string>();
        public RequestStatus Status { get; set; }
        public string AdminNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
