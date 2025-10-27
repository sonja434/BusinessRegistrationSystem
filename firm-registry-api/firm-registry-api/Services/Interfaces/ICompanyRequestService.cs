using firm_registry_api.DTOs;
using firm_registry_api.Models;

public interface ICompanyRequestService
{
    Task<CompanyRequest> CreateRequestAsync(CompanyRequestDto dto, int userId);
    Task<CompanyRequest> UpdateRequestByUserAsync(int requestId, UserUpdateCompanyRequestDto dto, int userId);
    Task<CompanyRequest> UpdateRequestByAdminAsync(int requestId, AdminUpdateCompanyRequestDto dto);
    Task<CompanyRequest> GetRequestByIdAsync(int id);
    Task<PagedResult<CompanyRequest>> GetRequestsByUserAsync(CompanyRequestQueryParams queryParams);
    Task<PagedResult<CompanyRequest>> GetAllRequestsAsync(CompanyRequestQueryParams queryParams);
    Task<byte[]> GenerateRequestPdfAsync(int requestId, int userId);
}
