using firm_registry_api.Models;

public class ActivityCode
{
    public int Id { get; set; }
    public string Code { get; set; } 
    public string Description { get; set; }
    public int ActivityGroupId { get; set; }
    public ActivityGroup ActivityGroup { get; set; }
}
