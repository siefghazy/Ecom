using ECOMMERECE.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECOMMERECE.Controllers
{
    [Route("error")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Error : ControllerBase
    {
        public ActionResult printError()
        {
            return NotFound(new ApiResponse(404));
        }
    }
}
