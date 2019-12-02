using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [Authorize]
        public IActionResult GetAllForUser()
        {
            return Ok(_purchaseService.GetPurchasesForUser());
        }

        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_purchaseService.Get(id));
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            _purchaseService.Remove(id);
            return Ok();
        }

        [Authorize]
        public IActionResult PurchaseProductById(int id)
        {
            _purchaseService.PurchaseProductById(id);
            return Ok();
        }


    }
}