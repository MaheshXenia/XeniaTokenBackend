using Microsoft.AspNetCore.Mvc;
using XeniaTokenBackend.Dto;
using XeniaTokenBackend.Repositories.Advertisement;
using XeniaTokenBackend.Repositories.Auth;

namespace XeniaTokenBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementController(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateAdvertisement([FromBody] CreateAdvertisementDto dto)
        {
            try
            {
                var result = await _advertisementRepository.CreateAdvertisementAsync(dto);
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

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetCompanyAdvertisements(int companyId)
        {
            try
            {
                var ads = await _advertisementRepository.GetCompanyAdvertisementsAsync(companyId);
                return Ok(ads);
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAdvertisementsByUser(int userId)
        {
            try
            {
                var ads = await _advertisementRepository.GetAdvertisementsByUserAsync(userId);
                return Ok(ads);
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

        [HttpPut("update/{advId}")]
        public async Task<IActionResult> UpdateAdvertisement(int advId, [FromBody] UpdateAdvertisementDto dto)
        {
            try
            {
                var result = await _advertisementRepository.UpdateAdvertisementAsync(advId, dto);
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

        [HttpDelete("delete/{advId}")]
        public async Task<IActionResult> DeleteAdvertisement(int advId)
        {
            try
            {
                var result = await _advertisementRepository.DeleteAdvertisementAsync(advId);
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
