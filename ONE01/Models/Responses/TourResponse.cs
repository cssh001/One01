namespace ONE01.Models.Responses
{
    public class TourResponse
    {
        public int Id { get; set; }
        public string Thumbnail { get; set; }

        public string Title { get; set; }

        public int? CountryId { get; set; }

        public int? ProvinceId { get; set; }

        public int? DistrictId { get; set; }

        public string AreaName { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string MapEmbed { get; set; }

        public List<TourImageResponse>? ImageDetails { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public static implicit operator TourResponse(List<TourResponse> v)
        {
            throw new NotImplementedException();
        }
    }
}
