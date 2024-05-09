namespace ONE01.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public required string? CategoryName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
