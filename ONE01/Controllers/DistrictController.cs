using Microsoft.AspNetCore.Mvc;
using ONE01.Enums;
using ONE01.Models.Responses;
using ONE01.Repositories;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController(IDistrictRepository _districtRepository):ControllerBase
    {
        [HttpGet]
        public async  Task<IActionResult> GetAllDistricts()
        {
            try
            {
                var districts = await _districtRepository.GetAllDistricts();

                return Ok(new ApiResponse<List<DistrictResponse>>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "success",
                    Total = districts.Count,
                    Data =districts,
                });
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
