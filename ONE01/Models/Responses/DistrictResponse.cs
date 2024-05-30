using System.Text.Json.Serialization;

namespace ONE01.Models.Responses
{
    public class DistrictResponse
    {
        
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }  // From Province table
        public string NameEn { get; set; }
        public string NameKh { get; set; }
        public string DistrictImage { get; set; }
        public string DistrictCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        
    }
}
