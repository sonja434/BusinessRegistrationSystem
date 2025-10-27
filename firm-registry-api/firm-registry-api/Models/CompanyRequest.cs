using firm_registry_api.Models.Enums;

namespace firm_registry_api.Models
{
    public abstract class CompanyRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int ActivityCodeId { get; set; }
        public ActivityCode ActivityCode { get; set; }
        public Address Address { get; set; }
        public CompanyType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<string> Documents { get; set; } = new List<string>();
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public int UserId { get; set; }
        public User User { get; set; }
        public string AdminNotes { get; set; } = string.Empty;

    }
}
