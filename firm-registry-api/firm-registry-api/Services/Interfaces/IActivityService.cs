using firm_registry_api.DTOs;

namespace firm_registry_api.Services.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityCodeDto>> GetCodesByGroupIdAsync(int groupId);
        Task<List<ActivityGroupDto>> GetGroupsBySectorIdAsync(int sectorId);
        Task<List<ActivitySectorDto>> GetAllSectorsAsync();
        Task<PagedResult<ActivityCodeDto>> GetPagedCodesAsync(PaginationQuery query);
    }
}
