using Microsoft.AspNetCore.Mvc;
using ONE01.Enums;
using ONE01.Models;
using ONE01.Models.Responses;
using ONE01.Repositories;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> _categoriesList = [];
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                _categoriesList = await _categoryRepository.GetAllCategories();
                return Ok(new ApiResponse<Category>()
                {
                    Data = _categoriesList,
                    Total = _categoriesList.Count,
                    ErrorCode = EErrorCode.Success,
                    Message = "Success",
                }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetCategoryById(int Id)
        {
            try
            {
                var categories = _categoryRepository.GetCategoryById(Id);

                if (categories == null)
                {
                    var apiResponse = new ApiResponse<Category>()
                    {
                        ErrorCode = EErrorCode.NotFound,
                        Message = "Categories not found",
                        Total = 0,
                        Data = [],
                    };
                    return NotFound(apiResponse);
                }
                else
                {
                    var apiResponse = new ApiResponse<Category>()
                    {
                        ErrorCode = EErrorCode.Success,
                        Message = "Success",
                        Total = categories.Count,
                        Data = categories
                    };
                    return Ok(apiResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)EErrorCode.ServerError, "Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(Category category)
        {
            try
            {
               await _categoryRepository.CreateCategory(category);
                var apiResponse = new ApiCreateResponse()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Category created successfully"
                };
                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return StatusCode((int)EErrorCode.ServerError, $"Server error with {ex}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, Category category)
        {
            try
            {
                await _categoryRepository.UpdateCategory(Id, category);
                var apiResponse = new ApiCreateResponse()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Category updated successfully"
                };
                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return StatusCode((int)EErrorCode.ServerError, $"Server error with {ex}");
            }
        }

    }
}