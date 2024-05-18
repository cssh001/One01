namespace ONE01.Models.Responses
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CityImage { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
