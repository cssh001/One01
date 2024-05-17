using Dapper;
using ONE01.Context;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;
using System.Data.Common;

namespace ONE01.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DapperContext _context;
        public CourseRepository(DapperContext context) => _context = context;

        public async Task CreateNewCourse(CourseRequest course)
        {

            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[CreateNewCourseProcedure]";
                var param = new {
                   CategoryId = course.CategoryId,
                   SubCategoryId = course.SubCategoryId,
                   Title =  course.Title,
                   Description = course.Description,
                   VideoLink = course.VideoLink,
                   Credit = course.Credit
                };
                await connection.ExecuteAsync(proc, param:param, commandType: CommandType.StoredProcedure);
            }
            catch (DbException ex)
            {
               
            };
        }

       
        public async Task<List<CourseResponse>> GetAllCourses()
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[GetAllCourseProcedure]";
                var response = await connection.QueryAsync<CourseResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving courses.", ex); 
            }
        }

        public async Task UpdateCourse(int Id, CourseRequest course)
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[UpdateCourseProcedure]";
                var param = new
                {
                    Id,
                    course.CategoryId,
                    course.SubCategoryId,
                    course.Title,
                    course.Description,
                    course.VideoLink,
                    course.Credit
                };
                await connection.ExecuteAsync(proc, param: param, commandType: CommandType.StoredProcedure);
            }
            catch (DbException ex)
            {

            };
        }
        public async Task DeleteCourse(int Id)
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[DeleteCourseProcedure]";
                var param = new { Id };
                await connection.ExecuteAsync(proc, param: param, commandType: CommandType.StoredProcedure);
            }
            catch (DbException ex)
            {

            };
        }

    }
}
