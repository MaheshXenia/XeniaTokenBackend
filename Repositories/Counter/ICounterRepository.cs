

using XeniaTokenBackend.Models;

namespace XeniaTokenBackend.Repositories.Counter
{
    public interface ICounterRepository
    {
        Task<IEnumerable<CounterDto>> GetCountersByDepartmentAsync(int depId);
    }
}
