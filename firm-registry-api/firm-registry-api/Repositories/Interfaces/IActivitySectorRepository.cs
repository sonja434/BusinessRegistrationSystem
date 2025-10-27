using firm_registry_api.Models;

namespace firm_registry_api.Repositories.Interfaces
{
    public interface IActivitySectorRepository
    {
        Task<List<ActivitySector>> GetAllAsync();
        Task<ActivitySector> GetByIdAsync(int id);
    }
}
