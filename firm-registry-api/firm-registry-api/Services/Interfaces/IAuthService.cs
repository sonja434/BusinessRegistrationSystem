using firm_registry_api.DTOs;
using firm_registry_api.Models;

namespace firm_registry_api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
