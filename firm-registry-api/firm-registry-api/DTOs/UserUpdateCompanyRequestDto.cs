using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class UserUpdateCompanyRequestDto
    {
        public List<IFormFile>? DocumentFiles { get; set; }
        public bool CancelRequest { get; set; } = false;
        public List<string>? ExistingDocuments { get; set; }
    }
}
