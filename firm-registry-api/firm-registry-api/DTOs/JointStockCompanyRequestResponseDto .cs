using System;
using System.Collections.Generic;

namespace firm_registry_api.DTOs
{
    public class JointStockCompanyRequestResponseDto : CompanyRequestResponseDto
    {
        public decimal ShareCapital { get; set; }
        public List<FounderDto> Shareholders { get; set; } = new List<FounderDto>();
        public List<string> BoardOfDirectors { get; set; } = new List<string>();
    }
}
