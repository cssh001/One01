using Microsoft.AspNetCore.Mvc;
using ONE01.Enums;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController(IProvinceRepository _provinceRepository): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProvinces()
        {
            try
            {
                var  provinces = await _provinceRepository.GetAllProvinces();
                return Ok(new ApiResponse<List<ProvinceResponse>>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Succuess",
                    Total = provinces.Count,
                    Data = provinces,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProvince(ProvinceRequest request)
        {
            try
            {
                await _provinceRepository.CreateNewProvince(request);
                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Created Successfully",
                    Total = null,
                    Data = new { request },
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProvince(int Id, ProvinceRequest request)
        {
            try
            {
                await _provinceRepository.UpdateProvince(Id, request);
                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Total = null,
                    Data = new { request },
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
