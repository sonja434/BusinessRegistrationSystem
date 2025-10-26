using firm_registry_api.DTOs;

namespace firm_registry_api.Services.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityGroupDto>> GetAllGroupsAsync();
        Task<List<ActivityCodeDto>> GetCodesByGroupIdAsync(int groupId);
    }
}
