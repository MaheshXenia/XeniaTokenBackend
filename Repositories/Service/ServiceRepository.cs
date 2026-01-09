
using Microsoft.EntityFrameworkCore;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;
using XeniaTokenBackend.Repositories.Department;

namespace XeniaTokenBackend.Repositories.Service
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

        public async Task<object> CreateServiceAsync(CreateServiceRequestDto dto)
        {
            bool serviceExists = await _context.xtm_Service
                .AnyAsync(s =>
                    s.SerDepID == dto.SerDepID &&
                    s.SerCompanyID == dto.SerCompanyID &&
                    s.SerName == dto.SerName
                );

            if (serviceExists)
                throw new Exception("Service name already exists for this department");

            var service = new xtm_Service
            {
                SerCompanyID = dto.SerCompanyID,
                SerDepID = dto.SerDepID,
                SerName = dto.SerName,
                SerStatus = dto.SerStatus
            };

            _context.xtm_Service.Add(service);
            var rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return new
                {
                    status = "success",
                    message = "Service created successfully"
                };
            }

            throw new Exception("Failed to create service. No rows affected.");
        }

        public async Task<object> UpdateServiceAsync(int serId, UpdateServiceRequestDto dto)
        {
            bool duplicateExists = await _context.xtm_Service
                .AnyAsync(s =>
                    s.SerDepID == dto.SerDepID &&
                    s.SerName == dto.SerName &&
                    s.SerID != serId
                );

            if (duplicateExists)
                return new { status = "error", message = "Service name already exists in this department" };

            var service = await _context.xtm_Service
                .FirstOrDefaultAsync(s => s.SerID == serId);

            if (service == null)
                throw new Exception("Service not found");

            service.SerName = dto.SerName;
            service.SerDepID = dto.SerDepID;
            service.SerStatus = dto.SerStatus;

            var rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return new { status = "success", message = "Service updated successfully" };
            }

            throw new Exception("Failed to update service. No rows affected.");
        }

        public async Task<List<ServiceDto>> GetServicesByDepartmentAsync(int depId)
        {
            return await _context.xtm_Service
                .Where(s => s.SerDepID == depId && s.SerStatus == true) 
                .Select(s => new ServiceDto
                {
                    ServiceID = s.SerID,
                    ServiceName = s.SerName
                })
                .ToListAsync();
        }

        public async Task<int> DeleteServiceAsync(int serId)
        {
            var service = await _context.xtm_Service
                .FirstOrDefaultAsync(s => s.SerID == serId);

            if (service == null)
                return 0;

            _context.xtm_Service.Remove(service);
            var rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected; 
        }


    }

}



