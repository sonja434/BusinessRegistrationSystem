namespace firm_registry_api.DTOs
{
    public class LimitedCompanyRequestDto : CompanyRequestDto
    {
        public string DirectorFullName { get; set; }
        public decimal ShareCapital { get; set; }
        public List<FounderDto> Founders { get; set; } = new List<FounderDto>();
    }

}
