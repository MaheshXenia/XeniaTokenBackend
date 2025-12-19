using System.Security.Claims;

namespace XeniaTokenBackend.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<(string? token, string? error)> LoginUserAsync(LoginRequestDto request);
        Task<object> GetUserByTokenAsync(ClaimsPrincipal user);
    }
}
