using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenApi.Repositories.Service;

namespace XeniaTokenApi.Controllers
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

    }
}
