namespace firm_registry_api.DTOs
{
    public class JointStockCompanyRequestDto : CompanyRequestDto
    {
        public decimal ShareCapital { get; set; } = 3000000;
        public List<FounderDto> Shareholders { get; set; } = new List<FounderDto>();
        public List<string> BoardOfDirectors { get; set; } = new List<string>();
    }

}
