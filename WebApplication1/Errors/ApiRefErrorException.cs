namespace ECOMMERECE.Errors
{
    public class ApiRefErrorException:ApiResponse
    {
        public string? _details  { get; set; }
        public ApiRefErrorException(int statusCode, string? msg, string? details) : base(statusCode,msg)
        {
            _details = details;
        }
    }
}
