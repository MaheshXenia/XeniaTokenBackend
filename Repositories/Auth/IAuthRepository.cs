using System.Security.Claims;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;

namespace XeniaTokenBackend.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<(string? token, string? error)> LoginUserAsync(LoginRequestDto request);
        Task<object> GetUserByTokenAsync(ClaimsPrincipal user);
        Task<xtm_Users> CreateUserAsync(xtm_Users user);
        Task<object> GetUsersByCompanyAsync(int companyId);
        Task<object> UpsertUserMapAsync(int userId, List<UserMapRequestDto> userMaps);
        Task<object> GetAppVersionAsync(string appName);
        Task<object> UpdateUserAsync(int userId, UpdateUserRequestDto dto);
        Task<object> DeleteUserAsync(int userId);

    }
}
