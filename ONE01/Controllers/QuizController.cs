using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ONE01.Enums;
using ONE01.Models;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;

namespace ONE01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private static List<Quiz> _quizList = [];

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
                _quizList = await _quizRepository.GetAllQuiz();
                return Ok(new ApiResponse<Quiz>() { 
                    ErrorCode = EErrorCode.Success,
                    Message = "Succuess",
                    Total = _quizList.Count,
                    Data = _quizList,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetQuizById(int Id)
        {
            var project = _quizList.Find(p => p.QuizId == Id);
            if (project == null)
            {
                return NotFound(new ApiResponse<Quiz>
                {
                    ErrorCode = EErrorCode.NotFound,
                    Message = "Project not found",
                    Data = [],
                });
            }
            return Ok(new ApiResponse<Quiz>
            {
                ErrorCode = EErrorCode.NotFound,
                Message = "Success",
                Data = _quizList,
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewQuiz(GameQuiz gameQuiz)
        {
            try
            {
                await _quizRepository.CreateNewQuiz(gameQuiz);
                return Ok(new ApiCreateResponse()
                {
                    ErrorCode = EErrorCode.Success,
                    Message = "Created Successfully",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500); 
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateQuiz(int Id, GameQuiz gameQuiz)
        {
            try
            {
                var success = await _quizRepository.UpdateQuiz(Id, gameQuiz);
                if (success)
                {
                    return Ok(new ApiCreateResponse
                    {
                        ErrorCode = EErrorCode.Success,
                        Message = "Updated Successfully",
                    });
                }
                else
                {
                    return NotFound(new ApiCreateResponse
                    {
                        ErrorCode = EErrorCode.NotFound,
                        Message = "Quiz not found",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
