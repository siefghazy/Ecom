namespace ECOMMERECE.Errors
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string ErrorMsg { get; set; }
        public ApiResponse(int status, string? msg = null)
        {
            statusCode = status;
            ErrorMsg = msg ?? defaultErrorMsg(status);
        }
        private string defaultErrorMsg(int status)
        {
            var message = status switch
            {
                400 => "bad request",
                500 => "internal server error",
                401 => "unAutorized",
                200=>"successfull"

            };
            return message;
        }
    }
}
