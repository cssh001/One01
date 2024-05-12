using Dapper;
using Microsoft.Data.SqlClient;
using ONE01.Context;
using ONE01.Models;
using ONE01.Models.Requests;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class QuizRepository(DapperContext context) : IQuizRepository
    {
        public async Task CreateNewQuiz(GameQuiz quiz)
        {
           
                using var connection = context.CreateConnection();
                var proc = "[DB01].[dbo].[CreateNewQuizProcedure]";
                var param = new
                {
                    quiz.CategoryId,
                    quiz.SubCategoryId,
                    quiz.GameName,
                    quiz.Title,
                    quiz.Question,
                    quiz.Image,
                    quiz.Options,
                    quiz.CorrectAnswer,
                 
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
        }

       

        public async Task<List<Quiz>> GetAllQuiz()
        {
            try
            {
                using var connection = context.CreateConnection();
                const string proc = "[DB01].[dbo].[GetAllQuizzesProcedure]";
                var reponse =  await connection.QueryAsync<Quiz>(proc, param: null, commandType: CommandType.StoredProcedure);
                return reponse.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; 
            }
        }

        public Task<List<Quiz>> GetQuizById(int Id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateQuiz(int Id, GameQuiz quiz)
        {
            try
            {
                using var connection = context.CreateConnection();
                var proc = "[DB01].[dbo].[UpdateQuizProcedure]";
                var param = new
                {
                    QuizId = Id,
                    quiz.CategoryId,
                    quiz.SubCategoryId,
                    quiz.GameName,
                    quiz.Title,
                    quiz.Question,
                    quiz.Image,
                    quiz.Options,
                    quiz.CorrectAnswer
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating quiz with Id {Id}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteQuiz(int Id)
        {
            try
            {
                using var connection = context.CreateConnection();
                var proc = "[DB01].[dbo].[DeleteQuizProcedure]";

                var rowsAffected = await connection.ExecuteAsync(proc, param: new { Id }, commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting quiz with Id {Id}: {ex.Message}");
                return false;
            }
        }
    }
}
