using Microsoft.AspNetCore.Mvc;
using ONE01.Enums;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCourse(CourseRequest course)
        {
            try
            {
                await _courseRepository.CreateNewCourse(course);
                return Ok(new ApiResponse<EmptyResult>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Data = Empty
                });
            }catch (Exception ex)
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
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var courses = await _courseRepository.GetAllCourses();
                return Ok(new ApiResponse<List<CourseResponse>>()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                    Total = courses.Count,
                    Data = courses,
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
    }
}
