namespace firm_registry_api.DTOs
{
    public class PartnershipRequestDto : CompanyRequestDto
    {
        public List<FounderDto> Partners { get; set; } = new List<FounderDto>();
    }

}
