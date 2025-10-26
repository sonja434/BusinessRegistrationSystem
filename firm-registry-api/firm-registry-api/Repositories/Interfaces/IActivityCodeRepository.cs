namespace firm_registry_api.Repositories.Interfaces
{
    public interface IActivityCodeRepository
    {
        Task<List<ActivityCode>> GetAllAsync();
        Task<List<ActivityCode>> GetByGroupIdAsync(int groupId);
        Task<ActivityCode> GetByIdAsync(int id);
        Task<(List<ActivityCode> items, int totalItems)> GetPagedAsync(
            int pageNumber, int pageSize, int? sectorId, int? groupId, string? search);
    }
}
