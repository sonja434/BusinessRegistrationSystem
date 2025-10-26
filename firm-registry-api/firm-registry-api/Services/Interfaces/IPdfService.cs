using firm_registry_api.Models;

namespace firm_registry_api.Services.Interfaces
{
    public interface IPdfService
    {
        Task<byte[]> GenerateCompanyRequestPdfAsync(CompanyRequest request);
    }
}
