using ECOMMERECE.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Data.Models;
using Store.Services.DTO;
using Store.Services.interfaces;
using Store.Services.services;

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
        [Cached(50)]
        public async Task<ActionResult> getAllproduct()
        {
            var products = await _productService.getAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [Cached(50)]
        public ActionResult getProductId(int id)
        {
            return Ok(_productService.getProductById(id));
        }
        [HttpPost]
        public void addProduct([FromForm] productDTO productDTO)
        {
            _productService.addProduct(productDTO);
        }
        [HttpGet("{id}")]
        public void deleteProduct(int id)
        {
            _productService.deleteProduct(id);
        }
        [HttpPost]
        public async Task addVariance([FromForm]varianceAddDTO varianceAddDTO)
        {
            await _productService.addVarianceAsync(varianceAddDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VarianceGetDTO>> getProductVariance(int id)
        {
            return Ok(await _productService.VarianceGet(id));
        }
    }
}
