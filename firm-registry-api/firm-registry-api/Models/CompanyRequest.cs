using firm_registry_api.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace firm_registry_api.Models
{
    public abstract class CompanyRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ActivityCode { get; set; } 
        public Address Address { get; set; }
        public CompanyType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<string> Documents { get; set; } = new List<string>();
        public string Status { get; set; } = "Pending";
    }
}
