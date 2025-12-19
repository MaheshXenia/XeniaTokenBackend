

using Microsoft.EntityFrameworkCore;
using XeniaTokenBackend.Models;


namespace XeniaTokenBackend.Repositories.Counter
{
    public class CounterRepository : ICounterRepository
    {
        private readonly ApplicationDbContext _context;
   

        public CounterRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;      
        }


        public async Task<IEnumerable<CounterDto>> GetCountersByDepartmentAsync(int depId)
        {
            var counters = await (from c in _context.xtm_Counter
                                  join d in _context.xtm_Department on c.DepID equals d.DepID
                                  where c.DepID == depId
                                  select new CounterDto
                                  {
                                      CounterID = c.CounterID,
                                      CounterName = c.CounterName,
                                      Status = c.Status,
                                      DepName = d.DepName
                                  })
                                  .ToListAsync();

            return counters;
        }

    }

}



