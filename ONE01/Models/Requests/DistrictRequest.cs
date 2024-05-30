namespace ONE01.Models.Requests
{
    public class DistrictRequest
    {
       
        public required int ProvinceId { get; set; }
        public required string NameEn { get; set; }
        public required string NameKh { get; set; }
        public string DistrictImage { get; set; }
        public string DistrictCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
       
    }
}
