namespace firm_registry_api.DTOs
{
    public class ActivitySectorDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } 
        public List<ActivityGroupDto> Groups { get; set; } = new List<ActivityGroupDto>();
    }
}
