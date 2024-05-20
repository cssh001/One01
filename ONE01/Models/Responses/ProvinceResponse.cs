using System.ComponentModel.DataAnnotations;

namespace ONE01.Models.Responses
{
    public class ProvinceResponse
    {
        public int Id { get; set; }

        public string ProvinceCode { get; set; }

        public string NameEn { get; set; }

        public string NameKh { get; set; }

        public int? CountryId { get; set; }

        public string ProvinceImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
