using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Enums;
using ONE01.Models;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Collections.Generic;

namespace ONE01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController: ControllerBase
    {
        private static List<SubCategory> _subCategoriesList = [];
        private readonly ISubCategoryRepository _repository;

        public SubCategoryController(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            _subCategoriesList = await _repository.GetAllSubCategory();

            var apiResponse = new ApiResponse<SubCategory>()
            {
                ErrorCode = EErrorCode.Success,
                Total = _subCategoriesList.Count,
                Data = _subCategoriesList,
                Message = "Success",

            };
            return new OkObjectResult(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategory subCategory)
        {
            await _repository.CreateSubCategoryAsync(subCategory);
            var response = new ApiCreateResponse()
            {
                Message = "Create New Data Successfully",
                ErrorCode = EErrorCode.Success,
            };

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            try
            {
                var subCategory = await _repository.GetSubCategoryByIdAsync(id);
                if (subCategory == null)
                {
                    return NotFound(); 
                }
                return Ok(subCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500); 
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateSubCategory(int Id,  SubCategory subCategory)
        {
            await _repository.UpdateSubCategory(Id, subCategory);
            var response = new ApiCreateResponse()
            {
                Message = "Updated Successfully",
                ErrorCode = EErrorCode.Success,
            };

            return Ok(response);
        }

    }
}
