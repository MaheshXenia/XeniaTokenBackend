using System.Security.Claims;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;

namespace XeniaTokenBackend.Repositories.Advertisement
{
    public interface IAdvertisementRepository
    {
        Task<object> CreateAdvertisementAsync(CreateAdvertisementDto dto);
        Task<List<AdvertisementDto>> GetCompanyAdvertisementsAsync(int companyId);
        Task<List<AdvertisementDto>> GetAdvertisementsByUserAsync(int userId);
        Task<object> UpdateAdvertisementAsync(int advId, UpdateAdvertisementDto dto);
        Task<object> DeleteAdvertisementAsync(int advId);

    }
}
