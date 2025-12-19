
using Microsoft.AspNetCore.Mvc;
using XeniaTokenBackend.Repositories.Counter;


namespace XeniaTokenBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly ICounterRepository _counterRepository;

        public CounterController(ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }

        [HttpGet("dep/{depId}")]
        public async Task<IActionResult> GetDepCounters(int depId)
        {
            try
            {
                var counters = await _counterRepository.GetCountersByDepartmentAsync(depId);

                if (counters == null || !counters.Any())
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "No counters found for this department.",
                        counters = new List<object>()
                    });
                }

                return Ok(new
                {
                    status = "success",
                    counters
                });
            }
            catch (System.Exception ex)
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
