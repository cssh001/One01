using ONE01.Enums;

namespace ONE01.Models.Responses
{
    public class ApiResponse<T>
    {
        public required EErrorCode ErrorCode { get; set; }
        public required string Message { get; set; }
        public int? Total {  get; set; }
        public required List<T> Data { get; set; }
    }
}
