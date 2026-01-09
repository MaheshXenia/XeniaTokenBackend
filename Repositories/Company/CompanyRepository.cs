using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Models;
using XeniaTokenBackend.Repositories.Token;

namespace XeniaTokenBackend.Repositories.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelperService _jwtHelperService;

        public CompanyRepository(ApplicationDbContext context, IConfiguration configuration, JwtHelperService jwtHelperService)
        {
            _context = context;
            _jwtHelperService = jwtHelperService;
        }

        public async Task<int> CreateCompanyAsync(CreateCompanyDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
        
                if (await _context.xtm_Company.AnyAsync(c => c.CompanyName == dto.CompanyName))
                    throw new Exception("Company already exists");

          
                if (await _context.xtm_Users.AnyAsync(u => u.Username == dto.Username))
                    throw new Exception("Username already exists");

          
                var company = new xtm_Company
                {
                    CompanyName = dto.CompanyName,
                    LicenseKey = dto.LicenseKey,
                    Status = true,
                    Country = dto.Country,
                    Address = dto.Address,
                    Email = dto.Email,
                    Validity = DateTime.UtcNow.AddDays(14),
                    IsExpired = false
                };
                _context.xtm_Company.Add(company);
                await _context.SaveChangesAsync();

      
                var settings = new xtm_CompanySettings
                {
                    CompanyID = company.CompanyID,
                    CollectCustomerName = false,
                    PrintCustomerName = false,
                    CollectCustomerMobileNumber = false,
                    PrintCustomerMobileNumber = false,
                    IsCustomCall = false
                };
                _context.xtm_CompanySettings.Add(settings);
                await _context.SaveChangesAsync();

     
                var department = new xtm_Department
                {
                    CompanyID = company.CompanyID,
                    DepName = dto.CompanyName,
                    DepExpire = DateTime.UtcNow.AddDays(14),
                    DepPrefix = dto.DepPrefix,
                    Status = true
                };
                _context.xtm_Department.Add(department);
                await _context.SaveChangesAsync();


                var user = new xtm_Users
                {
                    CompanyID = company.CompanyID,
                    Username = dto.Username,
                    Password = dto.Password,
                    TokenResetAllowed = true,
                    UserType = "Administrator",
                    Status = true
                };
                _context.xtm_Users.Add(user);
                await _context.SaveChangesAsync();

         
                var userMap = new xtm_UserMap
                {
                    UserID = user.UserID,
                    DepID = department.DepID,
                    Status = true
                };
                _context.xtm_UserMap.Add(userMap);
                await _context.SaveChangesAsync();

           
                var tokenMaster = new xtm_TokenMaster
                {
                    CompanyID = company.CompanyID,
                    DepID = department.DepID,
                    PrintTokenValue = 0,
                    TriggerValue = 0,
                    MaximumToken = 999
                };
                _context.xtm_TokenMaster.Add(tokenMaster);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return company.CompanyID;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> UpdateCompanyAsync(int companyId, UpdateCompanyDto dto)
        {
            var company = await _context.xtm_Company
                .FirstOrDefaultAsync(c => c.CompanyID == companyId);

            if (company == null)
                throw new Exception("Company not found");

            company.CompanyName = dto.CompanyName;
            company.LicenseKey = dto.LicenseKey;
            company.Status = dto.Status;
            company.Country = dto.Country;
            company.Address = dto.Address;
            company.Email = dto.Email;
            company.Validity = DateTime.UtcNow;
            company.IsExpired = dto.IsExpired;

            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<List<xtm_Company>> GetAllCompanyAsync(string search = "")
        {
            IQueryable<xtm_Company> query = _context.xtm_Company;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(c =>
                    c.CompanyName.ToLower().Contains(search) ||
                    c.LicenseKey.ToLower().Contains(search) ||
                    c.Address.ToLower().Contains(search) ||
                    c.Country.ToLower().Contains(search) ||
                    c.Email.ToLower().Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<xtm_Company?> GetCompanyByIdAsync(int companyId)
        {
            var company = await _context.xtm_Company
                .FirstOrDefaultAsync(c => c.CompanyID == companyId);

            return company; 
        }

    }
}
