using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models.Responses;
using ONE01.Repositories;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DapperContext _context;

        public CategoryController(DapperContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(Category category)
        {
            using var connection = _context.CreateConnection();
            var param = new { CategoryName = category.CategoryName, Description = category.Description };
            const string query = "INSERT INTO [DB01].[dbo].[Categories] (CategoryName, Description) VALUES (@CategoryName, @Description)";

            try
            {
                await connection.ExecuteAsync(query, param);
                return Ok("Create New Successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the category." + ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                using var connection = _context.CreateConnection();
                const string query = "SELECT [CategoryId], [CategoryName], [Description], [Image] FROM [DB01].[dbo].[Category_List] ORDER BY [CategoryId] DESC";
                var categories = await connection.QueryAsync<Category>(query);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                using var connection = _context.CreateConnection();
                var param = new { Id = id };
                const string query = $"SELECT [Id] as CategoryId, [CategoryName], [Description] FROM [DB01].[dbo].[Categories] WHERE [Id] = @Id";
                var categories = await connection.QuerySingleOrDefaultAsync<Category>(query, param);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            try
            {
                using var connection = _context.CreateConnection();
                var param = new
                {
                    CategoryId = id,
                    category.CategoryName,
                    category.Description
                };
                const string query = "EXEC [dbo].[UpdateCategoryProcedure] @CategoryId, @CategoryName, @Description";
                var categories = await connection.QueryAsync<Category>(query, param);
                return Ok(new {Message= "Category Updated Successfully"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            using var connection = _context.CreateConnection();
            var param  = new { CategoryId =  categoryId };
            const string query = $"DELETE FROM [DB01].[dbo].[Categories] WHERE Id = @CategoryId";
            var categories = await connection.QueryAsync<Category>(query, param);
            return Ok(categories);
        }


    }
}
