namespace ONE01.Models.Responses
{
    public class TourImageResponse
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string? ImageName { get; set; }
        public int ImageOrder { get; set; }

    }
}
