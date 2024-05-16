using System.ComponentModel.DataAnnotations;

namespace ONE01.Models.Requests
{
    public class CourseRequest
    {
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
        public required int SubCategoryId { get; set; }
        public string? Description { get; set; }
        public required string VideoLink { get; set; }
        public required string Credit { get; set; }
    }
}
