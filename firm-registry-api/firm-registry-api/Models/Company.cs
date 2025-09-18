using firm_registry_api.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace firm_registry_api.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ActivityCode { get; set; } 

        public string Address { get; set; }

        public CompanyType Type { get; set; } 
    }
}
