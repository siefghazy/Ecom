using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Dto;
using Store.Services.interfaces;

namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IbrandService _brandService;   
        public BrandController(IbrandService ibrand)
        {
            _brandService = ibrand;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<brandDto>>>  getAllBrands()
        {
            return Ok( await _brandService.getAllBrandsAsync());
        }
        [HttpGet]
        public async Task<ActionResult<brandDto>> getBrandById(int id)
        {
            return Ok(await _brandService.getProductById(id));
        }
    }
}
