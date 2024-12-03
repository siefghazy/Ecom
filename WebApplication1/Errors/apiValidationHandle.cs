namespace ECOMMERECE.Errors
{
    public class apiValidationHandle:ApiResponse
    {
       public  apiValidationHandle():base(400) 
        {

        }
        public IEnumerable<string> Errors{ get; set; }
    }
}
