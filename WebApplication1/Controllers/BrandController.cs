using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
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
        public ActionResult<IReadOnlyList<BrandDto>>  getAllBrands()
        {
           
            return Ok(  _brandService.getAllBrands());
        }
        [HttpGet("{id}")]
        public ActionResult<BrandDto> getBrandById(int id)
        {
            return Ok(_brandService.getProductById(id));
        }
        [HttpPost]
        public void addBrand([FromForm] BrandDto brand)
        {
            _brandService.addBrand(brand);
        }
        [HttpPost("{id}")]
        public void deleteBrand(int id)
        {
            _brandService.deleteBrand(id);

        }
        [HttpPut("{id}")]
        public void updateBrand(int?id,[FromForm]BrandDto brand)
        {
            _brandService.updateBrand(id,brand);
        }
    }
}
