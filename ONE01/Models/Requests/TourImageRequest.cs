namespace ONE01.Models.Requests
{
    public class TourImageRequest
    {
        public required int TourId { get; set; }
        public required string ImageName { get; set; }
        public int ImageOrder { get; set; }
    }
}
