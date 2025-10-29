using firm_registry_api.Models.firm_registry_api.Models;

namespace firm_registry_api.Models
{
    public class JointStockCompanyRequest : CompanyRequest
    {
        public decimal ShareCapital { get; set; } = 3000000;
        public List<Shareholder> Shareholders { get; set; } = new List<Shareholder>();
        public List<string> BoardOfDirectors { get; set; } = new List<string>();
    }
}
