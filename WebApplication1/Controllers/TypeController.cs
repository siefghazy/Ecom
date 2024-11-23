using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Dto;
using Store.Services.interfaces;

namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [HttpPost]
        public void addType([FromBody] typDto typDto)
        {
            _typeService.addType(typDto);
        }
        [HttpGet]
        public ActionResult<IReadOnlyList<typDto>> getAllTypes()
        {
            return Ok(_typeService.getAllType());
        }

        [HttpGet("{id}")]
        public ActionResult<typDto> getTypeById(int? id)
        {
            return Ok(_typeService.getTypeById(id));
        }
        [HttpPost("{id}")]
        public void deleteType(int? id)
        {
            _typeService.deleteType(id);
        }
        [HttpPut("{id}")]
        public void updateType(int? id, typDto typDto)
        {
            _typeService.updateType(id, typDto);
        }
    }
}
