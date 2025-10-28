using firm_registry_api.Models.Enums;
using System.Text.Json.Serialization;

namespace firm_registry_api.DTOs
{
    [JsonDerivedType(typeof(EntrepreneurRequestDto), nameof(CompanyType.PR))]
    [JsonDerivedType(typeof(LimitedCompanyRequestDto), nameof(CompanyType.DOO))]
    [JsonDerivedType(typeof(JointStockCompanyRequestDto), nameof(CompanyType.AD))]
    [JsonDerivedType(typeof(PartnershipRequestDto), nameof(CompanyType.OD))]
    [JsonDerivedType(typeof(LimitedPartnershipRequestDto), nameof(CompanyType.KD))]
    public abstract class CompanyRequestDto
    {
        public string CompanyName { get; set; }
        public int ActivityCodeId { get; set; }
        public AddressDto Address { get; set; } = new AddressDto();
        public CompanyType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;              
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<IFormFile>? DocumentFiles { get; set; }
        public int UserId { get; set; }
    }
}
