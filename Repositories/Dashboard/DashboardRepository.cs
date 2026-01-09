using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;
using XeniaTokenBackend.Repositories.Token;

namespace XeniaTokenBackend.Repositories.Dashboard
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelperService _jwtHelperService;

        public DashboardRepository(ApplicationDbContext context, IConfiguration configuration, JwtHelperService jwtHelperService)
        {
            _context = context;
            _jwtHelperService = jwtHelperService;
        }

        public async Task<(int PendingCount, int CompletedCount)> GetTokenCountsAsync(int companyId)
        {
            var pendingCount = await _context.xtm_TokenRegister
                .Where(t => t.CompanyID == companyId && (t.TokenStatus == "Pending" || t.TokenStatus == "onHold"))
                .CountAsync();

            var completedCount = await _context.xtm_TokenRegister
                .Where(t => t.CompanyID == companyId && t.TokenStatus == "Completed")
                .CountAsync();

            return (pendingCount, completedCount);
        }


    }
}
