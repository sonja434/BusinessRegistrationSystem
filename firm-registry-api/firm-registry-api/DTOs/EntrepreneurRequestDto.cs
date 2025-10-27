namespace firm_registry_api.DTOs
{
    public class EntrepreneurRequestDto : CompanyRequestDto
    {
        public FounderDto Owner { get; set; } = new FounderDto();          
    }
}
