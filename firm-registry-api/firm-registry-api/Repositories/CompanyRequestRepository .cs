using firm_registry_api.Data;
using firm_registry_api.DTOs;
using firm_registry_api.Models;
using firm_registry_api.Models.Enums;
using firm_registry_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace firm_registry_api.Repositories
{
    public class CompanyRequestRepository : ICompanyRequestRepository
    {
        private readonly AppDbContext _context;

        public CompanyRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyRequest> GetByIdAsync(int id)
        {
            var request = await _context.CompanyRequests
                .Include(c => c.Address)
                .Include(c => c.ActivityCode)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (request == null)
                return null;

            switch (request)
            {
                case EntrepreneurRequest entrepreneur:
                    await _context.Entry(entrepreneur).Reference(e => e.Owner).LoadAsync();
                    break;

                case LimitedCompanyRequest limited:
                    await _context.Entry(limited).Collection(l => l.Founders).LoadAsync();
                    break;

                case JointStockCompanyRequest joint:
                    await _context.Entry(joint).Collection(j => j.Shareholders).LoadAsync();
                    break;

                case LimitedPartnershipRequest lp:
                    await _context.Entry(lp).Collection(l => l.GeneralPartners).LoadAsync();
                    await _context.Entry(lp).Collection(l => l.LimitedPartners).LoadAsync();
                    break;

                case PartnershipRequest p:
                    await _context.Entry(p).Collection(pp => pp.Partners).LoadAsync();
                    break;
            }

            return request;
        }

        public async Task AddAsync(CompanyRequest request)
        {
            await _context.CompanyRequests.AddAsync(request);
        }

        public async Task UpdateAsync(CompanyRequest request)
        {
            _context.CompanyRequests.Update(request);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<CompanyRequest>> GetCompanyRequestsAsync(CompanyRequestQueryParams queryParams)
        {
            var query = _context.CompanyRequests
                .Include(c => c.Address)
                .Include(c => c.ActivityCode)
                .Include(c => c.User)
                .AsQueryable();

            if (queryParams.UserId.HasValue)
                query = query.Where(c => c.UserId == queryParams.UserId.Value);

            if (queryParams.Status.HasValue)
                query = query.Where(c => c.Status == queryParams.Status.Value);

            if (queryParams.Type.HasValue)
                query = query.Where(c => c.Type == queryParams.Type.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((queryParams.Page - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize)
                .ToListAsync();

            foreach (var request in items)
            {
                switch (request)
                {
                    case EntrepreneurRequest entrepreneur:
                        await _context.Entry(entrepreneur).Reference(e => e.Owner).LoadAsync();
                        break;
                    case LimitedCompanyRequest limited:
                        await _context.Entry(limited).Collection(l => l.Founders).LoadAsync();
                        break;
                    case JointStockCompanyRequest joint:
                        await _context.Entry(joint).Collection(j => j.Shareholders).LoadAsync();
                        break;
                    case LimitedPartnershipRequest lp:
                        await _context.Entry(lp).Collection(l => l.GeneralPartners).LoadAsync();
                        await _context.Entry(lp).Collection(l => l.LimitedPartners).LoadAsync();
                        break;
                    case PartnershipRequest p:
                        await _context.Entry(p).Collection(pp => pp.Partners).LoadAsync();
                        break;
                }
            }

            return new PagedResult<CompanyRequest>
            {
                Items = items,
                TotalCount = totalCount,
                Page = queryParams.Page,
                PageSize = queryParams.PageSize
            };
        }
    }
}
