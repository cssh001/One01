using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models;
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
            category.CreatedAt = DateTime.Now;
            category.ModifiedAt = DateTime.Now;
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


        public async Task<List<Category>> GetAllCategories()
        {
            using var connection = _context.CreateConnection();
            const string query = "[DB01].[dbo].[GetAllCategories]";
            var result = await connection.QueryAsync<Category>(query, param: null, commandType: CommandType.StoredProcedure);
            return result.AsList();

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
