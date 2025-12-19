


namespace XeniaTokenBackend.Repositories.Service
{
    public interface IServiceRepository
    {
        Task<IEnumerable<object>> GetAllServicesAsync(int companyId);

    }
}
