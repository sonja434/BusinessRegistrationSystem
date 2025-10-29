namespace firm_registry_api.Models
{
    public class ActivityGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivitySectorId { get; set; }
        public ActivitySector ActivitySector { get; set; }
        public List<ActivityCode> ActivityCodes { get; set; } = new List<ActivityCode>();
    }
}
