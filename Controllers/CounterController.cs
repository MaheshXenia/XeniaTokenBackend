
using Microsoft.AspNetCore.Mvc;
using XeniaTokenBackend.Dto;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateCounter([FromBody] CreateCounterRequestDto dto)
        {
            try
            {
                var result = await _counterRepository.CreateCounterAsync(dto);
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

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCounters(int companyId)
        {
            try
            {
                var counters = await _counterRepository.GetCountersByCompanyAsync(companyId);
                return Ok(counters);
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


        [HttpPut("update/{counterId}")]
        public async Task<IActionResult> UpdateCounter(int counterId, [FromBody] UpdateCounterRequestDto dto)
        {
            try
            {
                var result = await _counterRepository.UpdateCounterAsync(counterId, dto);
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


        [HttpDelete("delete/{counterId}")]
        public async Task<IActionResult> DeleteCounter(int counterId)
        {
            try
            {
                var result = await _counterRepository.DeleteCounterAsync(counterId);
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

    }
}
