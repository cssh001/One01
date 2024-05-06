using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;
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
            var query = "[DB01].[dbo].[CreateNewCategoryProcedure]";
            var param = new
            {
                category.CategoryName,
                category.Image,
                category.Description,
            };
            await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }


        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }


        public List<Category> GetAllCategories()
        {
            using var connection = _context.CreateConnection();
            const string query = "SELECT [CategoryId], [CategoryName], [Description], [Image] FROM [DB01].[dbo].[Category_List] ORDER BY [CategoryId] DESC";
            return connection.Query<Category>(query).ToList();
        }

        public List<Category> GetCategoryById(int Id)
        {
            using var connection = _context.CreateConnection();
            const string query = @"SELECT [CategoryId], [CategoryName], [Description], [Image] 
                                FROM [DB01].[dbo].[Category_List] 
                                WHERE [CategoryId] = @Id";
            return connection.Query<Category>(query, new { Id }).ToList();
           
        }

        public async Task UpdateCategory(int Id, Category category)
        {
            using var connection = _context.CreateConnection();
            var query = "[DB01].[dbo].[UpdateCategoryProcedure]";
            var param = new
            {
                CategoryId = Id,
                CategoryName = category.CategoryName,
                Description = category.Description,
            };

            await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }
    }
}
