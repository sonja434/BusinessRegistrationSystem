using System;
using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class PartnershipRequestResponseDto : CompanyRequestResponseDto
    {
        public List<FounderDto> Partners { get; set; } = new List<FounderDto>();
    }
}
