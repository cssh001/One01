namespace ONE01.Models.Requests
{
    public class TourRequest
    {
        public string Thumbnail { get; set; }

        public string Title { get; set; }

        public int? CountryId { get; set; }

        public int? ProvinceId { get; set; }

        public int? DistrictId { get; set; }

        public string AreaName { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string MapEmbed { get; set; }
    }
}
