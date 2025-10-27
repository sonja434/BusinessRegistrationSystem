using System;
using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class EntrepreneurRequestResponseDto : CompanyRequestResponseDto
    {
        public FounderDto Owner { get; set; } = new FounderDto();
    }
}
