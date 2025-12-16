
using Microsoft.EntityFrameworkCore;
using XeniaTokenApi.Models;
using XeniaTokenApi.Repositories.Department;

namespace XeniaTokenApi.Repositories.Service
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
   

        public ServiceRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;      
        }


        public async Task<IEnumerable<object>> GetAllServicesAsync(int companyId)
        {
            var services = await (from s in _context.xtm_Service
                                  join d in _context.xtm_Department
                                  on s.SerDepID equals d.DepID into depJoin
                                  from d in depJoin.DefaultIfEmpty()
                                  where s.SerCompanyID == companyId
                                  select new
                                  {
                                      s.SerID,
                                      s.SerCompanyID,
                                      s.SerDepID,
                                      s.SerName,
                                      s.SerStatus,
                                      DepName = d != null ? d.DepName : null
                                  }).ToListAsync();

            return services;
        }
    }

}



