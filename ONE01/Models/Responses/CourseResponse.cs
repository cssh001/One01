
namespace ONE01.Models.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
        public required int SubCategoryId { get; set; }
        public string? Description { get; set; }
        public required string VideoLink { get; set; }
        public required string Credit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
