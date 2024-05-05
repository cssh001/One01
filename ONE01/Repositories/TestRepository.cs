using Dapper;
using ONE01.Context;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ONE01.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DapperContext _context;

        public TestRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task UpdateCategoryAsync(int id, Category category)
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

                await connection.ExecuteAsync(query, param);
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                throw new Exception("Error updating category", ex);
            }
        }
    }
}
