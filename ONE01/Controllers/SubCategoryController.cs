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
        

       private readonly ISubCategoryRepository _repository;
        public SubCategoryController(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var response = await _repository.GetAllSubCategory();

            var apiResponse = new ApiResponse<SubCategory>()
            {
                MyErrorCode = EErrorCode.Success,
                Total = response.Count(),
                Data = response.ToList(),
                ErrorMessage = "Success",

            };

            return new OkObjectResult(apiResponse);

        }
       
    }
}
