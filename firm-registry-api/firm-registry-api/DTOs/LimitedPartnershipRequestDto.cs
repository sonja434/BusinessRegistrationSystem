namespace firm_registry_api.DTOs
{
    public class LimitedPartnershipRequestDto : CompanyRequestDto
    {
        public List<FounderDto> GeneralPartners { get; set; } = new List<FounderDto>();  
        public List<FounderDto> LimitedPartners { get; set; } = new List<FounderDto>();  
    }
}
