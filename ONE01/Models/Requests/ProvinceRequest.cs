using System.ComponentModel.DataAnnotations;

namespace ONE01.Models.Requests
{
    public class ProvinceRequest
    {
        public string ProvinceCode { get; set; }

        public string NameEn { get; set; }

        public string NameKh { get; set; }

        public int? CountryId { get; set; }

        public string ProvinceImage { get; set; }
    }
}
