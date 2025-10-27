using System;
using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class LimitedPartnershipRequestResponseDto : CompanyRequestResponseDto
    {
        public List<FounderDto> GeneralPartners { get; set; } = new List<FounderDto>();
        public List<FounderDto> LimitedPartners { get; set; } = new List<FounderDto>();
    }
}
