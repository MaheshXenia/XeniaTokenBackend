

using XeniaTokenApi.Models;
using XeniaTokenApi.Repositories.Department;

namespace XeniaTokenApi.Repositories.Department
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetDepartmentWebByIdAsync(int userId);

        Task<List<xtm_Department>> GetDepartmentWebAll(int companyId);

    }
}
