using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ONE01.Enums;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController(ITourRepository _tourRepository): ControllerBase
    {
        
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllToursWithImages()
        {
            try
            {
                var tours = await _tourRepository.GetAllTours();
                foreach (var tour in tours)
                {
                    var tourImage = await _tourRepository.GetTourImageByTourId(tour.Id);
                    tour.ImageDetails = tourImage;
                }
               return Ok(new ApiResponse<object>()
               {
                   ErrorCode = EErrorCode.Success,
                   Message = "success",
                   Total = tours.Count,
                   Data = tours,
               });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] TourRequest request)
        {
            try
            {
                int createdTourId = await _tourRepository.CreateNewTour(request);

                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Created Successfully",
                    Total = 1,
                    Data = new { request, createdTourId },
                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the tour.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating tour: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTour(int Id, [FromBody] TourRequest request)
        {
            try
            {
                bool IsSuccess = await _tourRepository.UpdateToure(Id,request);

                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "success",
                    Total = 1,
                    Data = new { request, IsSuccess },
                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the tour.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating tour: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost("ImageDetail")]
        public async Task<IActionResult> CreateTourImageDetail(TourImageRequest request)
        {
            try
            {
                await _tourRepository.CreateNewTourImage(request);
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
        [HttpDelete("DetailImageDetail/{Id}")]
        public async Task<IActionResult> DeleteTourImageDetailById(int Id)
        {
            try
            {
                bool isSuccess = await _tourRepository.DeleteImageDetailById(Id);

                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "success",
                    Total = 1,
                    Data = new {isSuccess },
                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the tour.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating tour: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTour(int Id)
        {
            try
            {
                bool isSuccess = await _tourRepository.DeleteTour(Id);

                return Ok(new ApiResponse<object>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "success",
                    Total = 1,
                    Data = new { isSuccess },
                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the tour.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating tour: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
