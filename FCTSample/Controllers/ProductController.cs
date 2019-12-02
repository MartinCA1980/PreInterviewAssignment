using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }
    }
}