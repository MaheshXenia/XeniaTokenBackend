using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenApi.Repositories.Department;


namespace XeniaTokenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly JwtHelperService _jwtHelperService;

        public DepartmentController(IDepartmentRepository departmentRepository, JwtHelperService jwtHelperService)
        {
            _departmentRepository = departmentRepository;
            _jwtHelperService = jwtHelperService;
        }


        [HttpGet("web/{userId}")]   
        public async Task<IActionResult> GetDepartmentWebById(int userId)
        {
            try
            {
                var departments = await _departmentRepository.GetDepartmentWebByIdAsync(userId);

                if (departments == null || departments.Count == 0)
                {
                    return NotFound(new
                    {
                        status = "error",
                        message = "No departments found"
                    });
                }

                return Ok(new
                {
                    status = "success",
                    department = departments
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



        [HttpGet("web/all/{companyId}")]
        public async Task<IActionResult> GetDepartmentWebAll(int companyId)
        {
            try
            {
                var departments = await _departmentRepository.GetDepartmentWebAll(companyId);

                if (departments == null || departments.Count == 0)
                {
                    return NotFound(new
                    {
                        status = "error",
                        message = "No departments found"
                    });
                }

                return Ok(new
                {
                    status = "success",
                    department = departments
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}
