using firm_registry_api.Models.Enums;

namespace firm_registry_api.DTOs
{
    public class CompanyRequestQueryParams
    {
        public int? UserId { get; set; } 
        public RequestStatus? Status { get; set; } 
        public CompanyType? Type { get; set; } 
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
