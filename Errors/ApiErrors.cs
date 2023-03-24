using System.Text.Json;

namespace WebAPIForHousing.Errors
{
    public class ApiErrors
    {
        public ApiErrors(int errorCode,string errorMessage, string errorDetails=null)
        {
            ErrorDetails = errorDetails;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string ErrorDetails { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
