﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult getAllproduct()
        {
            return Ok(_productService.getAllProducts());
        }
        [HttpGet("{id}")]
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
        
    }
}
