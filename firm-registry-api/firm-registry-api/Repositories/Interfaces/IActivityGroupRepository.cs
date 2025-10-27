using firm_registry_api.Models;

namespace firm_registry_api.Repositories.Interfaces
{
    public interface IActivityGroupRepository
    {
        Task<List<ActivityGroup>> GetAllAsync();
        Task<ActivityGroup> GetByIdAsync(int id);
        Task<List<ActivityGroup>> GetBySectorIdAsync(int sectorId);

    }
}
