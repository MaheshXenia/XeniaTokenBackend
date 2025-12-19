

using XeniaTokenBackend.Models;
using XeniaTokenBackend.Repositories.Department;

namespace XeniaTokenBackend.Repositories.Department
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetDepartmentWebByIdAsync(int userId);

        Task<List<xtm_Department>> GetDepartmentWebAll(int companyId);

    }
}
