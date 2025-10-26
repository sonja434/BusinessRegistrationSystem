using firm_registry_api.Data;
using firm_registry_api.Models;
using firm_registry_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace firm_registry_api.Repositories
{
    public class ActivityGroupRepository : IActivityGroupRepository
    {
        private readonly AppDbContext _context;

        public ActivityGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActivityGroup>> GetAllAsync()
        {
            return await _context.ActivityGroups
                .Include(g => g.ActivityCodes)
                .ToListAsync();
        }

        public async Task<ActivityGroup> GetByIdAsync(int id)
        {
            return await _context.ActivityGroups
                .Include(g => g.ActivityCodes)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<ActivityGroup>> GetBySectorIdAsync(int sectorId)
        {
            return await _context.ActivityGroups
                .Where(g => g.ActivitySectorId == sectorId)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

    }
}
