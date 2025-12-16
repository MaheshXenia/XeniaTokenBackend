

using XeniaTokenApi.Models;

namespace XeniaTokenApi.Repositories.Counter
{
    public interface ICounterRepository
    {
        Task<IEnumerable<CounterDto>> GetCountersByDepartmentAsync(int depId);
    }
}
