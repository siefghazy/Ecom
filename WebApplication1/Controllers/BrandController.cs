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
        public ActionResult<IReadOnlyList<brandDto>>  getAllBrands()
        {
            return Ok(  _brandService.getAllBrands());
        }
        [HttpGet("{id}")]
        public ActionResult<brandDto> getBrandById(int id)
        {
            return Ok(_brandService.getProductById(id));
        }
        [HttpPost]
        public void addBrand([FromForm] brandDto brandDto)
        {
            _brandService.addBrand(brandDto);
        }
        [HttpPost("{id}")]
        public void deleteBrand(int id)
        {
            _brandService.deleteBrand(id);

        }
        [HttpPut("{id}")]
        public void updateBrand(int?id,[FromForm]brandDto brandDto)
        {
            _brandService.updateBrand(id,brandDto);
        }
    }
}
