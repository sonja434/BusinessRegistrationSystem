using firm_registry_api.DTOs;
using firm_registry_api.Models;

namespace firm_registry_api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> UpdateProfileAsync(int userId, UpdateUserDto dto);
        Task<User?> GetProfileAsync(int userId);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    }
}
