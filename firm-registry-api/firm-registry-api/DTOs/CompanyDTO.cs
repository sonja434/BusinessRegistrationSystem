using firm_registry_api.Models.Enums;

namespace firm_registry_api.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string ActivityCode { get; set; }
        public string Address { get; set; }
        public CompanyType Type { get; set; }
    }
}
