using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;

        public QuizController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuiz()
        {
            try
            {
                var response = await _quizRepository.GetAllQuiz();
                var apiResponse = new ApiResponse<QuizResponse>()
                {
                   ErrorCode = Enums.EErrorCode.Success,
                   Message = "Success",
                   Total = response.Count,
                   Data = response,
                };
                return Ok(apiResponse); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewQuiz(GameQuiz gameQuiz)
        {
            try
            {
                await _quizRepository.CreateNewQuiz(gameQuiz);
                return Ok("Quiz created successfully"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500); 
            }
        }

        /*[HttpGet()]
        public async Task<IEnumerable<QuizResponse>> GetAllQuiz()
        {
            try
            {
                using var connection = context.CreateConnection();
                const string proc = "GetAllQuizzes";
                var response = await connection.QueryAsync<QuizResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Create new game 
        [HttpPost()]
        public async Task<ActionResult> AddNewGameQuiz(GameQuiz gameIQ)
        {
            try
            {
                using var connection = context.CreateConnection();
                var proc = "[DB01].[dbo].[CreateNewQuizProcedure]";
                var param = new
                {
                    gameIQ.CategoryId,
                    gameIQ.UserId,
                    gameIQ.GameName,
                    gameIQ.Title,
                    gameIQ.Question,
                    gameIQ.Image,
                    gameIQ.Options,
                    gameIQ.CorrectAnswer,
                    gameIQ.Answered
                };

                var response = await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);

                return Ok($"New quiz created successfully with CategoryId: {gameIQ.CategoryId} and Question: {gameIQ.Question}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete game 
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGameQuiz(int Id)
        {
            try
            {
                using var connection = context.CreateConnection();
                var param = new {Id};
                var query = "[DB01].[dbo].[DeleteQuizProcedure]";
                var response = await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                if (response > 0)
                {
                    return Ok("Quiz deleted successfully.");
                }
                else
                {
                    return NotFound("Quiz not found or could not be deleted.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }*/


    }
}
