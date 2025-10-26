namespace firm_registry_api.Models
{
    public class JointStockCompanyRequest : CompanyRequest
    {
        public decimal ShareCapital { get; set; } = 3000000;
        public List<Founder> Shareholders { get; set; } = new List<Founder>();
        public List<string> BoardOfDirectors { get; set; } = new List<string>(); 
    }
}
