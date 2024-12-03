using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;
using Store.Data.Models;
using Store.Services.DTO;
using Store.Services.interfaces;
using System.Runtime.CompilerServices;

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
        public void addType([FromBody] typeDto typDto)
        {
            _typeService.addType(typDto);
        }
        [HttpGet]
        public ActionResult<IReadOnlyList<prodType>> getAllTypes()
        {
            return Ok(_typeService.getAllType());
        }

        [HttpGet("{id}")]
        public ActionResult<prodType> getTypeById(int? id)
        {
            return Ok(_typeService.getTypeById(id));
        }
        [HttpPost("{id}")]
        public void deleteType(int? id)
        {
            _typeService.deleteType(id);
        }
        [HttpPut("{id}")]
        public void updateType(int? id, typeDto typDto)
        {
            _typeService.updateType(id, typDto);
        }
    }
}
