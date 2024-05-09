namespace ONE01.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? GameName { get; set; }
        public string? Title { get; set; }
        public required string Question { get; set; }
        public string? Image { get; set; }
        public required string Options { get; set; }
        public int CorrectAnswer { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
