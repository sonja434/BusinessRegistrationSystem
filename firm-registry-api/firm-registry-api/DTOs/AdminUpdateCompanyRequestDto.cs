using firm_registry_api.Models.Enums;

namespace firm_registry_api.DTOs
{
    public class AdminUpdateCompanyRequestDto
    {
        public RequestStatus Status { get; set; }          
        public string AdminNotes { get; set; } = string.Empty;  
    }
}
