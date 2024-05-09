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

        public async Task<List<SubCategory>>  GetAllSubCategory()
        {
           using var connetion = _context.CreateConnection();
            const string proc = "[DB01].[dbo].[GetAllSubCategoriesProcedure]";
             var result =  await connetion.QueryAsync<SubCategory>(proc, null, commandType: CommandType.StoredProcedure); ;
            return result.ToList(); 
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

        public async Task UpdateSubCategory(int Id, SubCategory subCategory)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "[DB01].[dbo].[UpdateSubCategoryProcedure]";
                    var param = new
                    {
                        Id,
                        subCategory.CategoryId,
                        subCategory.SubCategoryName,
                        subCategory.Image,
                        subCategory.Description
                    };
                    await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; 
            }
        }
    }
}
