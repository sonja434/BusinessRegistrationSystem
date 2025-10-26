namespace firm_registry_api.DTOs
{
    public class ActivityGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ActivityCodeDto> Codes { get; set; } = new List<ActivityCodeDto>();
    }
}
