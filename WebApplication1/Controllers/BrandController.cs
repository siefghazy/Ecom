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
            return Ok(  _brandService.getAllBrands());
        }
        [HttpGet("id")]
        public async Task<ActionResult<brandDto>> getBrandById(int id)
        {
            return Ok( _brandService.getProductById(id));
        }
       /* public async void addBrand()
        {
            return Ok(await _brandService.addBrand());
        }*/
    }
}
