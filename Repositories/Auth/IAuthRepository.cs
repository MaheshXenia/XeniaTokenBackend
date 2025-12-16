using System.Security.Claims;

namespace XeniaTokenApi.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<(string? token, string? error)> LoginUserAsync(LoginRequestDto request);
        Task<object> GetUserByTokenAsync(ClaimsPrincipal user);
    }
}
