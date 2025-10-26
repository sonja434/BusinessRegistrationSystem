using firm_registry_api.Data;
using firm_registry_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace firm_registry_api.Repositories
{
    public class ActivityCodeRepository : IActivityCodeRepository
    {
        private readonly AppDbContext _context;

        public ActivityCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActivityCode>> GetAllAsync()
        {
            return await _context.ActivityCodes
                .Include(c => c.ActivityGroup)
                .ToListAsync();
        }

        public async Task<List<ActivityCode>> GetByGroupIdAsync(int groupId)
        {
            return await _context.ActivityCodes
                .Where(c => c.ActivityGroupId == groupId)
                .ToListAsync();
        }

        public async Task<ActivityCode> GetByIdAsync(int id)
        {
            return await _context.ActivityCodes
                .Include(c => c.ActivityGroup)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<(List<ActivityCode> items, int totalItems)> GetPagedAsync(
    int pageNumber, int pageSize, int? sectorId, int? groupId, string? search)
        {
            var query = _context.ActivityCodes.AsQueryable();

            if (groupId.HasValue)
            {
                query = query.Where(a => a.ActivityGroupId == groupId.Value);
            }
            else if (sectorId.HasValue)
            {
                query = query.Where(a => a.ActivityGroup.ActivitySectorId == sectorId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a => a.Description.ToLower().Contains(search.ToLower()));
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .OrderBy(a => a.Code)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }

    }
}
