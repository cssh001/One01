﻿
using Azure;
using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Responses;
using ONE01.Repositories;
using System;
using System.Threading.Tasks;

namespace ONE01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {

                if (category == null || string.IsNullOrEmpty(category.CategoryName))
                {
                    return BadRequest("Invalid category data");
                }

                await _testRepository.UpdateCategoryAsync(id, category);

                return Ok("Data updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}