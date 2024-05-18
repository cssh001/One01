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
    public class CityController(ICityRepository _cityRepository) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateNewCity(CityRequest request)
        {
            try
            {
                await _cityRepository.CreateNewCity(request);
                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Data = new { request }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<EmptyResult>()
                {
                    ErrorCode = EErrorCode.ServerError,
                    Message = "An error occurred while creating the course. Please try again later.",
                    Data = Empty
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityRepository.GetAllCities();
                return Ok(new ApiResponse<List<CityResponse>>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Total = cities.Count,
                    Data = cities,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<EmptyResult>()
                {
                    ErrorCode = EErrorCode.ServerError,
                    Message = "Error while get all courses please try again",
                    Data = Empty
                });
                throw new Exception("Error with exception", ex);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCity(int Id, CityRequest request)
        {
            try
            {
                await _cityRepository.UpdateCity(Id, request);
                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Data = new { request }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.ServerError,
                    Message = "An error occurred while updating the course. Please try again later.",
                    Data = new { Id }
                });
            }

        }
    }
}
