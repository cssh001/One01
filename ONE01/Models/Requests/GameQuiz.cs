namespace ONE01.Models.Requests
{
    public class GameQuiz
    {
        public int QuizId { get; set; }
        public int? CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int? UserId { get; set; }
        public string? GameName { get; set; }
        public string Title { get; set; } 
        public string Question { get; set; }
        public string? Image { get; set; }  
        public string Options { get; set; }
        public int CorrectAnswer { get; set; }  
      
    }
}
