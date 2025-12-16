
using Microsoft.EntityFrameworkCore;
using XeniaTokenApi.Models;


namespace XeniaTokenApi.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
   

        public DepartmentRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;      
        }


        public async Task<List<DepartmentDto>> GetDepartmentWebByIdAsync(int userId)
        {
            var baseQuery = await (from d in _context.xtm_Department
                                   join um in _context.xtm_UserMap on d.DepID equals um.DepID
                                   where um.UserID == userId && um.Status
                                   select new
                                   {
                                       d.DepID,
                                       d.DepName,
                                       d.CompanyID,
                                       d.DepPrefix,
                                       d.DepExpire,
                                       d.Status
                                   }).ToListAsync();

            var depIds = baseQuery.Select(x => x.DepID).ToList();

            var counters = await _context.xtm_Counter
                .Where(c => depIds.Contains(c.DepID) && c.Status == true) 
                .Select(c => new
                {
                    c.CounterID,
                    c.CounterName,
                    c.Status,
                    c.DepID
                })
                .ToListAsync();

            var departments = baseQuery
                .Select(d => new DepartmentDto
                {
                    DepID = d.DepID,
                    DepName = d.DepName,
                    CompanyID = d.CompanyID,
                    DepPrefix = d.DepPrefix,
                    DepExpire = d.DepExpire,
                    Status = d.Status,
                    Counters = counters
                        .Where(c => c.DepID == d.DepID)
                        .Select(c => new xtm_Counter
                        {
                            CounterID = c.CounterID,
                            CounterName = c.CounterName,
                            Status = c.Status
                        })
                        .ToList()
                })
                .Where(d => d.Counters.Any()) 
                .ToList();

            return departments;
        }

        public async Task<List<xtm_Department>> GetDepartmentWebAll(int companyId)
        {
            var departments = await _context.xtm_Department
                                            .Where(d => d.CompanyID == companyId && d.Status == true)
                                            .AsNoTracking() 
                                            .ToListAsync();

            return departments;
        }


    }

}



