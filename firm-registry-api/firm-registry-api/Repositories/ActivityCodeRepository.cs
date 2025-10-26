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
    }
}
