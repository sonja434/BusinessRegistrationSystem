using firm_registry_api.Data;
using firm_registry_api.Models;
using firm_registry_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace firm_registry_api.Repositories
{
    public class ActivitySectorRepository : IActivitySectorRepository
    {
        private readonly AppDbContext _context;

        public ActivitySectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActivitySector>> GetAllAsync()
        {
            return await _context.ActivitySectors
                .Include(s => s.Groups)
                .ThenInclude(g => g.ActivityCodes)
                .OrderBy(s => s.Code)
                .ToListAsync();
        }

        public async Task<ActivitySector> GetByIdAsync(int id)
        {
            return await _context.ActivitySectors
                .Include(s => s.Groups)
                .ThenInclude(g => g.ActivityCodes)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
