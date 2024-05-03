﻿namespace ONE01.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public required string SubCategoryName { get; set; }
        public string? Image {  get; set; }
        public string? Description { get; set; }
    }
}
