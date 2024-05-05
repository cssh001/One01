using Dapper;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly DapperContext _context;
        public SubCategoryRepository(DapperContext context) {
            _context = context;
        }

        public async Task CreateSubCategoryAsync(SubCategory subCategory)
        {
            var connection = _context.CreateConnection();
            var query = "[DB01].[dbo].[CreateNewSubCategoryProcedure]";
            var param = new
            {
                subCategory.CategoryId,
                subCategory.SubCategoryName,
                subCategory.Image,
                subCategory.Description,
            };
            await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SubCategory>>  GetAllSubCategory()
        {
           using var connetion = _context.CreateConnection();
            const string query = @"SELECT [Id], [CategoryId], [SubCategoryName], [Image], [Description] 
                                   FROM [DB01].[dbo].[SubCategories] 
                                   ORDER BY [ID] DESC";
             return await connetion.QueryAsync<SubCategory>(query);
                 
        }

       public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int id)
       {
            using var connection = _context.CreateConnection();
            var param = new { Id = id };
            const string query = @"SELECT [Id], [CategoryId], [SubCategoryName], [Image], [Description] 
                                   FROM [DB01].[dbo].[SubCategories] 
                                   WHERE [Id] = @Id";
            return await connection.QueryAsync<SubCategory>(query, param);
        }

        public Task UpdateSubCategoryAsync(int Id, SubCategory subCategory)
        {
            throw new NotImplementedException();
        }
    }
}
