using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.interfaces;

namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult getAllproduct()
        {
            return Ok(_productService.getAllProducts());
        }
    }
}
