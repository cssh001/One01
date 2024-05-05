using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data.Common;

namespace ONE01.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategory(Category category)
        {
            using var connection = _context.CreateConnection();
            var param = new { CategoryName = category.CategoryName, Description = category.Description };
            const string query = "INSERT INTO [DB01].[dbo].[Categories] (CategoryName, Description) VALUES (@CategoryName, @Description)";

            await connection.ExecuteAsync(query, param);
        }

        public Task<IActionResult> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using var connection = _context.CreateConnection();
            const string query = "SELECT * FROM [DB01].[dbo].[Category_List]";
            return await connection.QueryAsync<Category>(query);
        }
    }
}
