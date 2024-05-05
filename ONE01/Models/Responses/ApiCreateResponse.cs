using ONE01.Enums;

namespace ONE01.Models.Responses
{
    public class ApiCreateResponse
    {
        public required EErrorCode ErrorCode { get; set; }
        public required string Message { get; set; }

    }
}
