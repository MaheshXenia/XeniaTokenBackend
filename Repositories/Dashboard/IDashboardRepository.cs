using System.Security.Claims;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;

namespace XeniaTokenBackend.Repositories.Dashboard
{
    public interface IDashboardRepository
    {
        Task<(int PendingCount, int CompletedCount)> GetTokenCountsAsync(int companyId);


    }
}
