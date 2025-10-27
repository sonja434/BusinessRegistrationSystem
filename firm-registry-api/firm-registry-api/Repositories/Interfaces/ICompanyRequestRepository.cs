using firm_registry_api.DTOs;
using firm_registry_api.Models;

namespace firm_registry_api.Repositories.Interfaces
{
    public interface ICompanyRequestRepository
    {
        Task<CompanyRequest> GetByIdAsync(int id);
        Task AddAsync(CompanyRequest request);
        Task UpdateAsync(CompanyRequest request);
        Task SaveChangesAsync();
        Task<PagedResult<CompanyRequest>> GetCompanyRequestsAsync(CompanyRequestQueryParams queryParams);
    }
}
