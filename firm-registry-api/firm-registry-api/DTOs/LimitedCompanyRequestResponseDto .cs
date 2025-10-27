using System;
using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class LimitedCompanyRequestResponseDto : CompanyRequestResponseDto
    {
        public string DirectorFullName { get; set; }
        public decimal ShareCapital { get; set; }
        public List<FounderDto> Founders { get; set; } = new List<FounderDto>();
    }
}
