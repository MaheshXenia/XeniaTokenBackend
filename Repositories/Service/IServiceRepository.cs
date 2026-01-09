


using XeniaTokenBackend.Dto;

namespace XeniaTokenBackend.Repositories.Service
{
    public interface IServiceRepository
    {
        Task<IEnumerable<object>> GetAllServicesAsync(int companyId);
        Task<object> CreateServiceAsync(CreateServiceRequestDto dto);
        Task<object> UpdateServiceAsync(int serId, UpdateServiceRequestDto dto);
        Task<List<ServiceDto>> GetServicesByDepartmentAsync(int depId);
        Task<int> DeleteServiceAsync(int serId);

    }
}
