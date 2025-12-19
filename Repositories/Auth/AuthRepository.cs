using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenBackend.Models;

namespace XeniaTokenBackend.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelperService _jwtHelperService;

        public AuthRepository(ApplicationDbContext context, IConfiguration configuration, JwtHelperService jwtHelperService)
        {
            _context = context;
            _jwtHelperService = jwtHelperService;
        }

        public async Task<(string? token, string? error)> LoginUserAsync(LoginRequestDto request)
        {
            var user = await _context.xtm_Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                return (null, "User not found");

            if (user.Password != request.Password)
                return (null, "Incorrect password");

            string adminPassword = user.Password;

            if (user.UserType != "Administrator" && user.UserType != "PlatformAdmin")
            {
                var adminUser = await _context.xtm_Users
                    .FirstOrDefaultAsync(u => u.CompanyID == user.CompanyID && u.UserType == "Administrator");

                if (adminUser == null)
                    return (null, "Administrator user not found");

                adminPassword = adminUser.Password;
            }

            var token = _jwtHelperService.GenerateJwtToken(user, adminPassword);
            return (token, null);
        }

        public async Task<object?> GetUserByTokenAsync(ClaimsPrincipal user)
        {
            if (user == null) return null;

            int? companyId = _jwtHelperService.GetCompanyId(user);

            var company = await _context.xtm_Company
                .Where(c => c.CompanyID == companyId)
                .Select(c => new
                {
                    c.CompanyID,
                    c.CompanyName,
                    c.Address,
                })
                .FirstOrDefaultAsync();


            var companySettings = await _context.xtm_CompanySettings
               .Where(c => c.CompanyID == companyId)
               .Select(c => new
               {
                   c.IsServiceEnable,
                   c.IsCustomCall,
               })
               .FirstOrDefaultAsync();

            return new
            {
                status = "success",
                iat = user.FindFirst("iat")?.Value,
                exp = user.FindFirst("exp")?.Value,
                user = new
                {
                    UserID = _jwtHelperService.GetUserId(user),
                    Username = user.FindFirst("Username")?.Value,
                    UserType = _jwtHelperService.GetUserType(user),
                    AdminPassword = _jwtHelperService.GetAdminPassword(user),
                    CompanyID = companyId,
                    CompanyName = company?.CompanyName,
                    CompanyAddress = company?.Address,
                    isCustomCall = companySettings?.IsCustomCall,
                    isServiceEnable = companySettings?.IsServiceEnable,
                    TokenResetAllowed = _jwtHelperService.GetAllowReset(user)
                }
            };
        }
    }
}
