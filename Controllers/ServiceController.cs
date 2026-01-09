using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Repositories.Service;

namespace XeniaTokenBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly JwtHelperService _jwtHelperService;

        public ServiceController(IServiceRepository serviceRepository, JwtHelperService jwtHelperService)
        {
            _serviceRepository = serviceRepository;
            _jwtHelperService = jwtHelperService;
        }


        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetAllService(int companyId)
        {
            try
            {
                var services = await _serviceRepository.GetAllServicesAsync(companyId);

                return Ok(new
                {
                    status = "success",
                    services
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "failed",
                    error = ex.Message
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceRequestDto dto)
        {
            try
            {
                var result = await _serviceRepository.CreateServiceAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpPut("update/{serId}")]
        public async Task<IActionResult> UpdateService(int serId, [FromBody] UpdateServiceRequestDto dto)
        {
            try
            {
                var result = await _serviceRepository.UpdateServiceAsync(serId, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }


        [HttpGet("department/{depId}")]
        public async Task<IActionResult> GetServicesByDepartment(int depId)
        {
            try
            {
                var services = await _serviceRepository.GetServicesByDepartmentAsync(depId);
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{serId}")]
        public async Task<IActionResult> DeleteService(int serId)
        {
            try
            {
                var rowsAffected = await _serviceRepository.DeleteServiceAsync(serId);

                if (rowsAffected > 0)
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "Service deleted successfully"
                    });
                }

                return NotFound(new
                {
                    status = "error",
                    message = "Service not found"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }


    }
}
