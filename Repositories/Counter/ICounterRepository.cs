

using XeniaTokenBackend.Dto;

namespace XeniaTokenBackend.Repositories.Counter
{
    public interface ICounterRepository
    {
        Task<IEnumerable<CounterDto>> GetCountersByDepartmentAsync(int depId);
        Task<object> CreateCounterAsync(CreateCounterRequestDto dto);
        Task<List<CounterResponseDto>> GetCountersByCompanyAsync(int companyId);
        Task<object> UpdateCounterAsync(int counterId, UpdateCounterRequestDto dto);
        Task<object> DeleteCounterAsync(int counterId);

    }
}
